
function showForm() {
    document.getElementById('add-koi-form').style.display = 'block';
}

function hideForm() {
    document.getElementById('add-koi-form').style.display = 'none';
}

// Đổi thành hàm deleteKoi để khớp với tên hàm gọi trong nút xóa
function deleteKoi(koiItem) {
    koiItem.remove(); 
}

function submitKoi() {
var name = document.getElementById('name').value;
var age = document.getElementById('age').value;
var length = document.getElementById('length').value;
var weight = document.getElementById('weight').value;
var sex = document.getElementById('sex').value;
var pond = document.getElementById('pond').value;
var breeder = document.getElementById('breeder').value;
var imageFile = document.getElementById('koiImage').files[0];

if (name && age && length && weight && sex && pond && breeder && imageFile) {
        var reader = new FileReader();

reader.onload = function(e) {
            var koiItem = document.createElement('div');
koiItem.className = 'koi-item';
koiItem.innerHTML = `
<img src="${e.target.result}" alt="Koi Image">
    <div class="koi-info">
        <strong>Name:</strong> ${name}<br>
            <strong>Age:</strong> ${age} years<br>
                <strong>Length:</strong> ${length} cm<br>
                    <strong>Weight:</strong> ${weight} g<br>
                        <strong>Sex:</strong> ${sex}<br>
                            <strong>Pond:</strong> ${pond}<br>
                                <strong>Breeder:</strong> ${breeder}
                            </div>
                            <button onclick="deleteKoi(this.parentElement)" style="background-color: red; color: white;">X</button>
                            `;

                            document.getElementById('koi-list').appendChild(koiItem);
                            document.getElementById('name').value = '';
                            document.getElementById('age').value = '';
                            document.getElementById('length').value = '';
                            document.getElementById('weight').value = '';
                            document.getElementById('sex').value = '';
                            document.getElementById('pond').value = '';
                            document.getElementById('breeder').value = '';
                            document.getElementById('koiImage').value = '';
                            hideForm();
        };
                            reader.readAsDataURL(imageFile);
    } else {
                                alert('Please fill out all fields and add an image.');
    }
}