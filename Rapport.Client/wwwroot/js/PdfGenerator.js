function DownloadPdf(filename, byteBase64) {
    var link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/octet-stream;base64" + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

function ViewPdf(iframeId, byteBase64) {
    document.getElementById(iframeId).innerHTML = "";
    var ifrm = document.createElement('iframe')
    ifrm.setAttribute("src", "data:application/octet-stream;base64" + byteBase64);
    ifrm.style.width = "100%";
    ifrm.style.height = "680px";
    document.getElementById(iFrameId).appendChild(ifrm);
}

function OpenPdfNewTab(filename, byteBase64) {
    var blob = base64BLob(byteBase64);
    var blobURL = URL.createObjectURL(blob);
    window.open(blobURL);
}

function base64BLob(b64Data) {
    sliceSize = 512;
    var byteCharacters = atob(b64Data);
    var byteArrayes = [];
    for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        var slice = byteCharacters.slice(offset, offset + sliceSize);
        var byteNumbers = var Array(slice.length);
        for (var i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }
        var byteArray = new Uint8Array(byteNumbers);

        byteArray.push(byteArray);

    }

    var blob = new Blob(byteArray, { type: 'application/pdf' });
    return blob;
}

function Print() {
    window.print();
}