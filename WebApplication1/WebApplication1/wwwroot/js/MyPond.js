
function showForm() {
    document.getElementById('add-pond-form').style.display = 'block';
}

function hideForm() {
    document.getElementById('add-pond-form').style.display = 'none';
}

function deletePond(pondItem) {
    pondItem.remove(); 
}

function submitPond() {
    var name = document.getElementById('name').value;
var number = document.getElementById('number').value;
var volume = document.getElementById('volume').value;
var depth = document.getElementById('depth').value;
var pumping = document.getElementById('pumping').value;
var drains = document.getElementById('drains').value;
var skimmers = document.getElementById('skimmers').value;
var imageFile = document.getElementById('PondImage').files[0];

if (name && number && volume && depth && pumping && drains && skimmers && imageFile) {
        var reader = new FileReader();

reader.onload = function(e) {
            var pondItem = document.createElement('div');
pondItem.className = 'pond-item';
pondItem.innerHTML = `
<img src="${e.target.result}" alt="Pond Image">
    <div class="pond-info">
        <strong>Name:</strong> ${name}<br>
            <strong>Number of Fish:</strong> ${number}<br>
                <strong>Volume:</strong> ${volume} liters<br>
                    <strong>Depth:</strong> ${depth} cm<br>
                        <strong>Pumping capacity:</strong> ${pumping} liters/minute<br>
                            <strong>Drains:</strong> ${drains}<br>
                                <strong>Skimmers:</strong> ${skimmers}
                            </div>
                            <button onclick="deletePond(this.parentElement)" style=" position: absolute; top: 310px; right: 230px; background-color: red; color: white;">X</button>
                            `;

                            document.getElementById('pond-list').appendChild(pondItem);
                            document.getElementById('name').value = '';
                            document.getElementById('number').value = '';
                            document.getElementById('volume').value = '';
                            document.getElementById('depth').value = '';
                            document.getElementById('pumping').value = '';
                            document.getElementById('drains').value = '';
                            document.getElementById('skimmers').value = '';
                            document.getElementById('PondImage').value = '';
                            hideForm();
        };
                            reader.readAsDataURL(imageFile);
    } else {
                                alert('Please fill out all fields and add an image.');
    }
}