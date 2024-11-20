document.addEventListener('DOMContentLoaded', function() {
    const items = document.querySelectorAll('.cart-content-product');
    const totalPriceElement = document.querySelector('.total-price');
    const totalPriceExtraElement = document.querySelector('.total-price-extra');

    function updatePrice(item) {
        const quantityInput = item.querySelector('.number');
        const priceDisplay = item.querySelector('.subtotal');
        const unitPrice = parseInt(item.getAttribute('data-price'));
        const quantity = parseInt(quantityInput.value) || 0;
        const price = (quantity * unitPrice).toLocaleString() + ' đ';
        priceDisplay.textContent = price;
    }

    function updateTotalPrice() {
        let totalPrice = 0;
        const items = document.querySelectorAll('.cart-content-product');
        items.forEach(item => {
            const quantityInput = item.querySelector('.number');
            const quantity = parseInt(quantityInput.value) || 0;
            const unitPrice = parseInt(item.getAttribute('data-price'));
            totalPrice += quantity * unitPrice;
        });
        totalPriceElement.textContent = totalPrice.toLocaleString() + ' đ';
        totalPriceExtraElement.textContent = totalPrice.toLocaleString() + ' đ';
    }

    document.getElementById('update-cart').addEventListener('click', function() {
        const items = document.querySelectorAll('.cart-content-product');
        items.forEach(item => {
            updatePrice(item);
        });
        updateTotalPrice();
    });
});

function removeItem(element) {
    var item = element.parentElement;
    item.parentElement.removeChild(item);
    updateTotalPrice();
}