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