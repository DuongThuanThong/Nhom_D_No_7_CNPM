
//cuon thanh nav xuong se thu nho lai
window.onscroll = function() {  
  var logo = document.querySelector('.logo');
  var scrollTop = window.scrollY;  

  if (scrollTop > 50) {  
    
      logo.style.width = "12%";
      logo.style.transition = "0.1s ease-in-out"; 
  } else {  
    
    logo.style.width = "15%";
      logo.style.transition = "0.1s  ease-in-out"; 
      
  }  
};


        