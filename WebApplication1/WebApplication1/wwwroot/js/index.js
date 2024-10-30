function increment() {
    let input = document.getElementById("number");
    let currentValue = parseInt(input.value) || 0; // Parse as integer, default to 0 if invalid
    input.value = currentValue + 1; // Increase value by 1
  }
  
  function decrement() {
    let input = document.getElementById("number");
    let currentValue = parseInt(input.value) || 0; // Parse as integer, default to 0 if invalid
    input.value = currentValue > 1 ? currentValue - 1 : 1; // Decrease by 1, minimum 1
  }