// button cong tru trong phan them gio hang
function increment(element) {
  let input = element.previousElementSibling || element.parentElement.querySelector('.number');
  let currentValue = parseInt(input.value) || 0;
  input.value = currentValue + 1;
}

function decrement(element) {
    let input = element.nextElementSibling || element.parentElement.querySelector('.number');
    let currentValue = parseInt(input.value) || 0;
    input.value = currentValue > 1 ? currentValue - 1 : 1;
}
