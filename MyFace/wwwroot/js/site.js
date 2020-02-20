window.addEventListener("load",function(){
   console.log("Hello TechSwitch")
   function removePost(ele){
      var index=ele.id.indexOf("-");
      var elementID=ele.id.substring(index+1);

      var element=document.getElementById("post-"+elementID);
      element.remove();
      element=document.getElementById("img-"+elementID);
      element.remove();
      element=document.getElementById("message-"+elementID);
      element.remove();
      element=document.getElementById("postlike-"+elementID);
      element.remove();

   }

   document.getElementById("myfaceNewpost").addEventListener("click", function(event){
      event.preventDefault();
   });

// Get the modal
   var modal = document.getElementById("myModal");

// Get the button that opens the modal
   var btn = document.getElementById("myfaceNewpost");
 
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks on the button, open the modal
   btn.onclick = function() {
      modal.style.display = "block";
  
   }

   // When the user clicks on <span> (x), close the modal
   span.onclick = function() {
      modal.style.display = "none";
      console.log(span);
   }

   modal.onclick=function(){
      modal.style.display = "none";
   }
});

