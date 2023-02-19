function logout(){
    localStorage.removeItem("myToken");
}
function MyFunction(){
    var tk = localStorage.getItem("myToken");
    console.log(tk);

function SkillProfile(data){
        let count = 11;
        data[3].forEach(function(item,index){
            count +=1;



            var dive = document.createElement('div');
            dive.setAttribute('class','row');
            
            dive.innerHTML = `
            <div class="col-10">
            <div class="educol1">
              <h5>${item.certificationName}</h5>
              <h6>${item.acquiredFrom}</h6>
              <p class="cgpa skillend">License No - ${item.certLicence}</p>
            
            </div>
          </div>

          <div class="col-2">
            <div class="edutoolbar">
                <button style= "border:orangered; background-color:white;"  type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight${count}" aria-controls="offcanvasRight"><i style="font-size: 1.1rem;" class="bi  bi-pencil-fill  edicon"></i></i></button>

                <div style="background-color: orangered;" class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasRight${count}" aria-labelledby="offcanvasRightLabel">
                  <div class="offcanvas-header">
                    <h5 class="offcanvas-title" id="offcanvasRightLabel">Update Education</h5>
                    
                
                    <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                  </div>
                  <div>
                    <div class="form">
                       
                        <form  class="login-form" name="formcontact1">
                            <input type="text" placeholder="Certification Name" value="${item.certificationName}" id="uacertname${count}"/>
                            <input type="text" placeholder="Certification Provider" value="${item.acquiredFrom}" id = "uacerprovider${count}"/>
                            <input type="text" placeholder="License No" value="${item.certLicence}" id="ualicno${count}"/>
                
                          <!-- <p class="message" >Not registered? <a href="#">Create an account</a></p> -->
                        </form>
                        <button class="frbut" onclick="UpdateCertification(${item.certId},${count})">Update</button>
                
                      </div>
                      </div>
                  <div class="offcanvas-body">
                    ...
                  </div>
                </div>
               <!-- <a class="aic" href=""> <i style="font-size: 1.6rem;" class="bi  bi-pencil-fill  edicon"></i></a> -->
               &nbsp;
               &nbsp;

                <a class="aic" onclick="DeleteCertification(${item.certId})" href="#"><i style="font-size: 1rem;" class="bi bi-trash3-fill delicon"></i></a>
            </div>
          </div>
            `;

            document.getElementById('certbody').appendChild(dive);
        })
    




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

            // EducationProfile(data);
            SkillProfile(data);

          
      
        }catch(error){
            console.log(error);
        }
    }
    asyncGet();
}
MyFunction();

function DeleteCertification(certId){
    var tk = localStorage.getItem("myToken");
    console.log(tk,certId);

    const asyncPost = async () =>{
        try{
            const response = await fetch(`https://localhost:7277/api/Auth/Certification/Delete`,{
                method:'DELETE',
                headers:{
                  'Content-Type':'application/json',

                    'Accept': '*/*',

                },  body:JSON.stringify({
                    "token": tk,
                    "id": certId
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


function UpdateCertification(certid,unum){
    var tk      = localStorage.getItem("myToken");
    var insname = document.getElementById(`uacertname${unum}`).value;
    var cname   = document.getElementById(`uacerprovider${unum}`).value;
    var cgpa    = document.getElementById(`ualicno${unum}`).value;

    console.log(tk,insname,cname,cgpa,certid,unum);

    const asyncPost = async () =>{
        try{
            const response = await fetch(`https://localhost:7277/api/Auth/Certification/Update`,{
                method:'PUT',
                headers:{
                  'Content-Type':'application/json',

                    'Accept': '*/*',

                },  body:JSON.stringify({
                    "certId": certid,
                    "token": tk,
                    "certificationName": insname,
                    "acquiredFrom": cname,
                    "certLicence": cgpa
                })
              
            });
            const data = await response.text();
            console.log(data);
            if(data === "Unable to update"){
                alert("Please fill the form correctly");
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


function AddCertification(){
    var tk = localStorage.getItem("myToken");

    // getting input values
    var certname = document.getElementById('acertname').value;
    var provname = document.getElementById('acerprovider').value;
    var licno = document.getElementById('alicno').value;
    console.log(certname,provname,licno);
    const asyncPost = async () =>{
        try{
            const response = await fetch(`https://localhost:7277/api/Auth/Certification/Add`,{
                method:'POST',
                headers:{
                  'Content-Type':'application/json',

                    'Accept': '*/*',

                },  body:JSON.stringify({
                    "token": tk,
                    "certificationName": certname,
                    "acquiredFrom": provname,
                    "certLicence": licno
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