function showAlert(name) {
    alert('Hello ' + name);
}

async function callStaticCsharpMethod() {
    await DotNet.invokeMethodAsync("BooksStore", "Sum", 3, 5)
        .then(data => {
            console.log(data);
        })
        .catch(error => {
            // Handle the error here. write to log
            console.error(error);
        })
}

function triggerOnWindowResized(dotnetObjRef) {
    // Subscribe to the window.onresize event and
    // trigger a method that will trigger the .NET
    // method and pass the width and height as
    // parameters to it
    window.onresize = function () {
        dotnetObjRef.invokeMethodAsync('OnWindowResized', window.innerWidth, window.innerHeight);
    }
}