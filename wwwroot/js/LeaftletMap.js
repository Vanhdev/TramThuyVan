export function initializeMap(s) {
    require([
        "esri/config",
        "esri/WebMap",
        "esri/views/MapView",
        "esri/widgets/ScaleBar",
        "esri/Graphic",
        "esri/layers/GraphicsLayer",
    ], function (esriConfig, WebMap, MapView, ScaleBar, Graphic, GraphicsLayer) {

        esriConfig.apiKey = "AAPKbd588929596149d6a69a4028998445f3N2D9U93PV19XMwqnDkM8mDVIr7IlVmDDRT54IBvLUin4eF1RwE4lxRCNs33bFksI";

        const webmap = new WebMap({
            portalItem: {
                id: "395a872338aa4767a66065d17eacbc26"
            }
        });

        const view = new MapView({
            container: "map",
            map: webmap,
            zoom: 8
        });

        const scalebar = new ScaleBar({
            view: view
        });

        view.ui.add(scalebar, "bottom-left");

        const graphicsLayer = new GraphicsLayer();
        webmap.add(graphicsLayer);

        const point = {
            type: "point",
            longitude: 105.892655,
            latitude: 20.994235
        };
        const simpleMarkerSymbol = {
            type: "picture-marker",
            url: "https://img.icons8.com/ios-filled/50/visit.png",
            width: "32px",
            height: "32px"
        };

        const pointGraphic = new Graphic({
            geometry: point,
            symbol: simpleMarkerSymbol,
            attributes: {
                Name: "Trạm Thanh Trì",
            }
        });
        graphicsLayer.add(pointGraphic);

        //view.on("click", function (event) {
        //    view.hitTest(event)
        //        .then(function (response) {
        //            // do something with the result graphic
        //            var graphic = response.results[0].graphic;
        //            return graphic.attributes.Name;
        //        });
        //});

        view.when(() => {
            resolve(view);
        });
    });
}

export function viewClick(view) {
    console.log(view);
}

