function getAllElementsWithAttribute(attribute, value) {
    var allElements = document.getElementsByTagName('*');
    for (var i = 0, n = allElements.length; i < n; i++) {
        if (allElements[i].getAttribute(attribute) !== null) {
            if (allElements[i].getAttribute(attribute) === value) {
                return allElements[i];
            }
        }
    }
    return null;
}
var codeOutput = document.getElementsByTagName('code')[0];
codeOutput.textContent = 'Waiting...';
var input = getAllElementsWithAttribute('data-event-property', 'Face Detection');
setTimeout(function () {
    input.click();
}, 100);

var interval = setInterval(function () {
    var codeOutput = document.getElementsByTagName('code')[0];
    if (codeOutput.textContent.indexOf("JSON") !== -1) {
        codeOutput.style.backgroundColor = 'green';
        var returnValue = codeOutput.textContent;
        returnValue = returnValue.split("JSON:")[1];
        var returnDiv = document.createElement("div");
        returnDiv.id = "ReturnToConsole";
        returnDiv.innerHTML = returnValue;
        //alert(codeOutput.textContent);
        document.body.appendChild(returnDiv);
        clearInterval(interval);
    }
}, 250);