function saveMessageJS(firstName, lastName) {
	//alert(firstName + ' ' + lastName + '. Record has been saved successfully. Hello from JavaScript!')
    document.getElementById('divServerValidation').innerText = firstName + ' ' + lastName + '. Record has been saved successfully. Hello from JavaScript! (Blazor)';
}


function setFocusOnElement(element) {
	element.focus();
}

function getCities() {

    //throw 'Something has gone wrong JS';

    var cities = ['(Blazor)', 'New York', 'Los Angeles', 'Chicago'];
    return cities;
}
