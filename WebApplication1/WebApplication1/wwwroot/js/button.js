// button cong tru trong phan them gio hang
function increment() {
    let input = document.getElementById("number");
    let currentValue = parseInt(input.value) || 0; 
    input.value = currentValue + 1; 
  }
  
  function decrement() {
    let input = document.getElementById("number");
    let currentValue = parseInt(input.value) || 0; 
    input.value = currentValue > 1 ? currentValue - 1 : 1; 
  }
