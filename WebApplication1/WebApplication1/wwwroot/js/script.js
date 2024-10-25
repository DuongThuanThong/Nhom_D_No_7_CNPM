const togglePassword = document.getElementById('togglePassword');
const passwordInput = document.getElementById('password');
const eyeIcon = document.getElementById('eyeIcon');

togglePassword.addEventListener('click', function () {
    // Toggle giữa type 'password' và 'text'
    const type = passwordInput.getAttribute('type') === 'password' ? 'text' : 'password';
    passwordInput.setAttribute('type', type);

    // Tùy chọn: Thay đổi icon
    eyeIcon.classList.toggle('fa-eye'); // Hiện
    eyeIcon.classList.toggle('fa-eye-slash'); // Ẩn
});
