document.getElementById('toggleButton1').addEventListener('click', function() {
    var content = document.getElementById('toggleContent1');
    content.classList.toggle('show');

    if (content.classList.contains('show')) {
        this.textContent = 'Tôi có thể thanh toán bằng cách nào?';
    } else {
        this.textContent = 'Tôi có thể thanh toán bằng cách nào?';
    }
    
     });
document.getElementById('toggleButton2').addEventListener('click', function() {
    var content = document.getElementById('toggleContent2');
    content.classList.toggle('show');

    if (content.classList.contains('show')) {
        this.textContent = 'Tôi có thể tìm hóa đơn mình ở đâu?';
    } else {
        this.textContent = 'Tôi có thể tìm hóa đơn mình ở đâu?';
    }
    
     });
document.getElementById('toggleButton3').addEventListener('click', function() {
    var content = document.getElementById('toggleContent3');
    content.classList.toggle('show');

    if (content.classList.contains('show')) {
        this.textContent = 'Làm thế nào tôi có thể trả lại thứ gì đó?';
    } else {
        this.textContent = 'Làm thế nào tôi có thể trả lại thứ gì đó?';
    }
    
     });
document.getElementById('toggleButton4').addEventListener('click', function() {
    var content = document.getElementById('toggleContent4');
    content.classList.toggle('show');

    if (content.classList.contains('show')) {
        this.textContent = 'Mất bao lâu để đơn hàng của tôi đến nơi?';
    } else {
        this.textContent = 'Mất bao lâu để đơn hàng của tôi đến nơi?';
    }
    
     });