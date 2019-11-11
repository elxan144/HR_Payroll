

// brands.addEventListener("click", function(){
//   alert("sas");
// })

// $(".brands").click(function(){
//   $(".sidebar").css({"width": "50px"});
// })


window.addEventListener('load',function(){
let sidebar = document.getElementById("side");
let brands = document.getElementById("brands");

brands.addEventListener("click",function(e){
  e.preventDefault();
  sidebar.style.width = '30px';
});
});



