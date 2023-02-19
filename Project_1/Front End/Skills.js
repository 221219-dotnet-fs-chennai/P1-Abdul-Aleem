function logout(){
    localStorage.removeItem("myToken");
}
function MyFunction() {
    var tk = localStorage.getItem("myToken");
    console.log(tk);

    // User details section
    
    

    // User Education section

   

    function SkillProfile(data){
        count = 11;
        data[1].forEach(function(item,index){
            count +=1;

            var divs = document.createElement('div');
            divs.setAttribute('class','row');
            divs.innerHTML = `
            <div class="col-10">
            <div class="educol1">
              <h5>${item.skillName}</h5>
              <p class="cgpa skillend">Experience - ${item.skillExperience}</p>
              
            </div>
          </div>
          <div class="col-2">
            <div class="edutoolbar">
                <button style= "border:orangered; background-color:white;"  type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight${count}" aria-controls="offcanvasRight"><i style="font-size: 1rem;" class="bi  bi-pencil-fill  edicon"></i></i></button>

                <div style="background-color: orangered;" class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasRight${count}" aria-labelledby="offcanvasRightLabel">
                  <div class="offcanvas-header">
                    <h5 class="offcanvas-title" id="offcanvasRightLabel">Update Skill</h5>
                    
                
                    <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                  </div>
                  <div>
                    <div class="form">
                       
                        <form  class="login-form" name="formcontact1">
                            <input type="text" placeholder="Skill Name" value=${item.skillName} id="uaddsname${count}"/>
                            <input type="text" placeholder="Skill Experience" value=${item.skillExperience} id = "uaddsexperience${count}"/>
                
                
                          <!-- <p class="message" >Not registered? <a href="#">Create an account</a></p> -->
                        </form>
                        <button class="frbut" onclick="UpdateSkill(${item.skillId},${count})">Update</button>
                
                      </div>
                      </div>
                  <div class="offcanvas-body">
                    ...
                  </div>
                </div>
               <!-- <a class="aic" href=""> <i style="font-size: 1.6rem;" class="bi  bi-pencil-fill  edicon"></i></a> -->
               
                <a class="aic"  onclick="DeleteSkill(${item.skillId})" href="#"><i style="font-size: 1rem; padding-right:5px" class="bi bi-trash3-fill delicon"></i></a>
            </div>
          </div>

            `;
            document.getElementById('skillbody').appendChild(divs);

        });
    }

 








    const asyncGet = async () =>{
        try{
            const response = await fetch(`https://localhost:7277/api/Auth/GetAll/${tk}`,{
                method:'GET',
                headers:{
                  'Content-Type':'application/json',

                    'Accept': '*/*',

                },
              
            });
            const data = await response.json();
            console.log(data);

            // BodyProfile(data);
            // EducationProfile(data);
            SkillProfile(data);
            // CompanyProfile(data);
            // CertificationProfile(data);
      
        }catch(error){
            console.log(error);
        }
    }
    asyncGet();





}
MyFunction();





function DeleteSkill(skillID){
        console.log(skillID);
            var tk = localStorage.getItem("myToken");


        const asyncPost = async () =>{
                    try{
                        const response = await fetch(`https://localhost:7277/api/Auth/Skill/Delete`,{
                            method:'DELETE',
                            headers:{
                              'Content-Type':'application/json',
            
                                'Accept': '*/*',
            
                            },  body:JSON.stringify({
                                "token": tk,
                                "id": skillID
                            })
                          
                        });
                        const data = await response.text();
                        console.log(data);
                        if(data === "Unable to delete"){
                            alert("Unable to delete");
                        }
                        else{
                        alert("Deleted successfully");
                        location.reload();
                        }
                       
                  
                    }catch(error){
                        console.log(error);
                        alert(error);
                    }
                }
                asyncPost();
}







function UpdateSkill(skid,unum){
    var tk = localStorage.getItem("myToken");
    var skname = document.getElementById(`uaddsname${unum}`).value;
    var ex = document.getElementById(`uaddsexperience${unum}`).value;

    console.log(tk,skid,skname,ex);

    const asyncPost = async () =>{
                try{
                    const response = await fetch(`https://localhost:7277/api/Auth/Skill/Update`,{
                        method:'PUT',
                        headers:{
                          'Content-Type':'application/json',
        
                            'Accept': '*/*',
        
                        },  body:JSON.stringify({
                            "token": tk,
                            "skillId": skid,
                            "skillName": skname,
                            "skillExperience": ex
                        })
                      
                    });
                    const data = await response.text();
                    console.log(data);
                    if(data === "Unable to update"){
                        alert("Please fill the form correctly");
                    }
                    else if(data.status == 400){
                        alert("Wrong experience entered");
                    }
                    else{
                    alert("Updated  successfully");
                    location.reload();
                    }
                   
              
                }catch(error){
                    console.log(error);
                    alert(error);
                }
            }
            asyncPost();



}





function AddSkills(){
     var tk = localStorage.getItem("myToken");
        var skname = document.getElementById('addsname').value;
    var ex = document.getElementById('addex').value;
    console.log(skname,ex,tk);

    const asyncPost = async () =>{
        try{
            const response = await fetch(`https://localhost:7277/api/Auth/Skill/Add`,{
                method:'POST',
                headers:{
                  'Content-Type':'application/json',

                    'Accept': '*/*',

                },  body:JSON.stringify({
                    "token": tk,
                    "skillName": skname,
                    "skillExperience": ex
                })
              
            });
            const data = await response.json();
            console.log(data);
            if(data.status === 400){
                alert("Please fill the form correctly");
            }
            else{
            alert("Added successfully");
            location.reload();
            }
           
      
        }catch(error){
            console.log(error);
            alert(error);
        }
    }
    asyncPost();


}