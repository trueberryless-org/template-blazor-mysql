// listen for page resize
function resizeListener(dotnethelper) {
    $(window).resize(() => {
        let browserHeight = $(window).innerHeight();
        let browserWidth = $(window).innerWidth();
        dotnethelper.invokeMethodAsync('SetBrowserDimensions', browserWidth, browserHeight).then(() => {
            // success, do nothing
        }).catch(error => {
            console.log("Error during browser resize: " + error);
        });
    });

    let browserHeight = $(window).innerHeight();
    let browserWidth = $(window).innerWidth();
    dotnethelper.invokeMethodAsync('SetBrowserDimensions', browserWidth, browserHeight).then(() => {
        // success, do nothing
    }).catch(error => {
        console.log("Error during browser resize: " + error);
    });
}

function scrollListener(element) {
    return element.scrollTop;
}