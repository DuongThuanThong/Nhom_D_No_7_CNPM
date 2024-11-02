//slider trang homepage

const titles = [  
    "Chất lượng cao nhất",  
    "Đảm bảo hài lòng"  
  ];  
  
  const descriptions = [  
    "Chúng tôi luôn chú ý đến chất lượng cao nhất của sản phẩm!",  
    "Chúng tôi luôn làm việc để mang đến sự hài lòng tối đa cho bạn!"  
  ];  
  
  const images = [  
    "/img/koiproduct.png",  
    "/img/koiproduct1.png"  
  ];  
  
  let currentIndex = 0;  
  const titleElement = document.getElementById('title');  
        const descriptionElement = document.getElementById('description');  
        const imgElement = document.getElementById('img');  
  
        function updateSlider() {  
            //lam mo cac phan tu tam thoi
            titleElement.style.opacity = 0;  
            descriptionElement.style.opacity = 0;  
            imgElement.style.opacity = 0;  
            document.querySelector('.content').style.animation = 'none'; // Reset animation cua content  
  
            
            setTimeout(() => {  
                titleElement.textContent = titles[currentIndex];  
                descriptionElement.textContent = descriptions[currentIndex];  
                imgElement.src = images[currentIndex];  
  
                // Reset animation de no co the chay lai
                document.querySelector('.content').style.animation = 'ani 0.5s ease forwards'; 
  
                // hien thi lai cac phan tu 
                titleElement.style.opacity = 1;  
                descriptionElement.style.opacity = 1;  
                imgElement.style.opacity = 1;  
            }, 500);  
        }  
  
        // nut next,prev
        document.getElementById('next').addEventListener('click', () => {  
            currentIndex = (currentIndex + 1) % titles.length;  
            updateSlider();  
        });  
  
        document.getElementById('prev').addEventListener('click', () => {  
            currentIndex = (currentIndex - 1 + titles.length) % titles.length;  
            updateSlider();  
        });  
  
       
        updateSlider();  
  