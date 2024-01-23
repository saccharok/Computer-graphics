const WIDTH = window.innerWidth - 15;
const HEIGHT = window.innerHeight - 100;

const URL = "https://borzzzenko.github.io/ComputerGraphics/Three.js-kitchen/";

// Load .obj model with .mtl
function loadMTLplusOBJ(mtlURL, objURL, loadFunction) {
	const objLoader = new THREE.OBJLoader();
	const mtlLoader = new THREE.MTLLoader();
	mtlLoader.load(mtlURL, (materials) => {
		materials.preload();
		objLoader.setMaterials(materials);
		
		objLoader.load(objURL, loadFunction);
	})
}

function main() {
	// Create scene, camera and render
	var scene = new THREE.Scene();
	scene.background = new THREE.Color(0xAAAAAA);

	const FOV = 90;
	const ASPECT = WIDTH/HEIGHT;
	const NEAR = 0.1;
	const FAR = 100;
	
	var camera = new THREE.PerspectiveCamera(FOV, ASPECT, NEAR, FAR);
	camera.position.z = -5;

	var renderer = new THREE.WebGLRenderer();
	renderer.setSize(WIDTH, HEIGHT);
	renderer.shadowMap.enabled = true;
	document.body.appendChild(renderer.domElement);

	// Camera controls
	const controls = new THREE.OrbitControls(camera, renderer.domElement);
	controls.update();
	
	// Floor
	const planeSize = 10;
	const textureLoader = new THREE.TextureLoader();
	
	const floorTexture = textureLoader.load(URL + "textures/wood-floor.jpg");
	floorTexture.wrapS = THREE.RepeatWrapping;
	floorTexture.wrapT = THREE.RepeatWrapping;
	floorTexture.magFilter = THREE.NearestFilter;
	
	const repeats = planeSize / 2;
	floorTexture.repeat.set(repeats, repeats);

	const planeGeo = new THREE.PlaneBufferGeometry(planeSize, planeSize);
	const planeMat = new THREE.MeshLambertMaterial({
		map: floorTexture,
		side: THREE.DoubleSide,
	});
	
	const floor = new THREE.Mesh(planeGeo, planeMat);
	floor.rotation.x = Math.PI * -0.5;
	floor.position.set(0, 0.1, 0);
	floor.receiveShadow = false;
	
	scene.add(floor);

	// Adding room walls
	let width = 10;
	let height = 5;
	let depth = 10;
	
	var geometry = new THREE.BoxGeometry(width, height, depth);
	var material = new THREE.MeshPhongMaterial({
		color: 0xffffff,
		side: THREE.DoubleSide
	});

	var roomCube = new THREE.Mesh(geometry, material);
	roomCube.receiveShadow = true;
	roomCube.position.set(0, 2.5, 0);
	
	scene.add(roomCube);

	// Lamp fiber
	var fiberRadius = 0.2;
	var fiberHeight = 5;
	
	var fiberGeometry = new THREE.CylinderGeometry(fiberRadius,
		 fiberRadius, fiberHeight);
	var fiberMaterial = new THREE.MeshPhongMaterial();
	
	var lampFiber = new THREE.Mesh(fiberGeometry, fiberMaterial);
	lampFiber.position.set(0, 4.7, 0);
	lampFiber.scale.set(0.1, 0.1, 0.1);
	
	scene.add(lampFiber);
	
	// Lamp
	var lampRadius = 2;
	var lampSegments = 64;

	var lampGeometry = new THREE.SphereGeometry(lampRadius, lampSegments,
		 lampSegments);
	var lampMaterial = new THREE.MeshBasicMaterial({
		color: 0xffffff,
	});
	
	var lamp = new THREE.Mesh(lampGeometry, lampMaterial);
	lamp.position.set(0, 4.5, 0);
	lamp.scale.set(0.1, 0.1, 0.1);
	
	scene.add(lamp);

	// Lamp light
	var lampLightIntensity = 1;
	var lampLightDistance = 15;

	const lampLight = new THREE.PointLight( 0xffffff, lampLightIntensity,
		 lampLightDistance);
	lampLight.position.set(0, 4.5, 0);
	lampLight.castShadow = true;
	
	scene.add(lampLight);

	// Table
	const tableTexture = textureLoader.load(URL + "textures/table-black.jpg");
	tableTexture.magFilter = THREE.NearestFilter
	
	// Table leg
	var legTopRadius = 0.15;
	var legBottomRadius = 0.1;
	var legHeight = 1.27;
	var legSegnments = 64;

	var tableLegGeometry = new THREE.CylinderGeometry(legTopRadius, legBottomRadius,
		legHeight, legSegnments);
	var legMaterial = new THREE.MeshPhongMaterial({
		color: 0xdaa520,
  		emissive: 0x000000,
  		specular: 0xbcbcbc,
		map: tableTexture,
		roughness: 0,
	});
	
	var tableLeg = new THREE.Mesh(tableLegGeometry, legMaterial);
	tableLeg.position.set(2, 0.75,  -1.5);
	tableLeg.castShadow = true;
	tableLeg.receiveShadow = true;

	scene.add(tableLeg);

	// Table top
	var tableTopRadius = 1.5;
	var tableBottomRadius = 1.5;
	var tableHeight = 0.1;
	var tableSegnments = 64;

	var tableGeometry = new THREE.CylinderGeometry(tableTopRadius, tableBottomRadius,
		tableHeight, tableSegnments);
	var tableMaterial = new THREE.MeshPhongMaterial({
		color: 0xdaa520,
  		emissive: 0x000000,
  		specular: 0xbcbcbc,
		map: tableTexture,
		roughness: 0,
	});
	
	var table = new THREE.Mesh(tableGeometry, tableMaterial);
	table.position.set(2, 1.4, -1.5);
	table.castShadow = true;
	table.receiveShadow = true;

	scene.add(table);

	// Table bottom stand
	var tableStandTopRadius = 0.5;
	var tableStandBottomRadius = 0.5;
	var tableStandHeight = 0.1;
	var tableStandSegnments = 64;

	var tableStandGeometry = new THREE.CylinderGeometry(tableStandTopRadius,
		 tableStandBottomRadius, tableStandHeight, tableStandSegnments);
	var tableStandMaterial = new THREE.MeshStandardMaterial({
		map: tableTexture,
		roughness: 0,
	});
	
	var tableStand = new THREE.Mesh(tableStandGeometry, tableStandMaterial);
	tableStand.position.set(2, 0.1, -1.5);
	tableStand.castShadow = true;
	tableStand.receiveShadow = true;

	scene.add(tableStand)
	
	// Desk lamp light
	var deskLampLightIntensity = 2;
	var deskLampLightDistance = 0;
	var deskLampLightAngle = 0.5;
	var deskLampLightPenumbra = 0.3;

	const deskLampLight = new THREE.SpotLight( 0xf0d75d, deskLampLightIntensity,
		deskLampLightDistance, deskLampLightAngle, deskLampLightPenumbra);
	deskLampLight.position.set(2.8, 2.6, -1.2);
	deskLampLight.target.position.set(2, 1.5, -1);
	deskLampLight.castShadow = true;
	
	scene.add(deskLampLight);
	scene.add(deskLampLight.target);

	// Animation loop
	var animate = function() {
		requestAnimationFrame(animate);

		controls.update();

		renderer.render(scene, camera);
	}

	animate();
}

main();
