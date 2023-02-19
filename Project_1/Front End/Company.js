function logout(){
    localStorage.removeItem("myToken");
}
function MyFunction(){
    var tk = localStorage.getItem("myToken");
    console.log(tk);


    function CompanyProfile(data){
            let count = 11;
            data[2].forEach(function(item,index){
                count +=1;
                let startDate = item.startDate;
                let endDate  = item.endDate;
    
    
                var dive = document.createElement('div');
                dive.setAttribute('class','row');
                
                dive.innerHTML = ` <div class="col-10">
                <div class="educol1">
                  <h5>${item.about}</h5>
                  <h6>${item.compName}</h6>
                  <div class="edudate">
                    <p>${startDate.substr(0,10)}</p>
                    &nbsp;
                    <p>to</p>
                    &nbsp;
                    <p>${endDate.substr(0,10)}</p>
                  </div>
                </div>
              </div>
    
              <div class="col-2">
                <div class="edutoolbar">
                    <button style= "border:orangered; background-color:white;"  type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasRight${count}" aria-controls="offcanvasRight"><i style="font-size: 1.2rem;" class="bi  bi-pencil-fill  edicon"></i></i></button>
    
                    <div style="background-color: orangered;" class="offcanvas offcanvas-end" tabindex="-1" id="offcanvasRight${count}" aria-labelledby="offcanvasRightLabel">
                      <div class="offcanvas-header">
                        <h5 class="offcanvas-title" id="offcanvasRightLabel">Update Education</h5>
                        
                    
                        <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                      </div>
                      <div>
                        <div class="form">
                           
                            <form  class="login-form" name="formcontact1">
                                <input type="text" placeholder="Designation" value = ${item.about} id="uadddesig${count}"/>
                                <input type="text" placeholder="Company Name" value = ${item.compName} id = "uaddcompname${count}"/>
                                <input type="text" placeholder="Start Date" value = ${startDate.substr(0,10)} id="uaddsdate${count}"/>
                                <input type="text" placeholder="End Date" value = ${endDate.substr(0,10)} id="uaddedate${count}"/>
                    
                    
                              <!-- <p class="message" >Not registered? <a href="#">Create an account</a></p> -->
                            </form>
                            <button class="frbut" onclick="UpdateCompany(${item.compId},${count})">Update</button>
                    
                          </div>
                          </div>
                      <div class="offcanvas-body">
                        ...
                      </div>
                    </div>
                   <!-- <a class="aic" href=""> <i style="font-size: 1rem;" class="bi  bi-pencil-fill  edicon"></i></a> -->
                    <br>
                    <br>
                    <a class="aic" onclick="DeleteCompany(${item.compId})" href="#"><i style="font-size: 1.2rem;" class="bi bi-trash3-fill delicon"></i></a>
                </div>
              </div>
                `;
    
                document.getElementById('compbody').appendChild(dive);
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

            // SkillProfile(data);
            CompanyProfile(data);
          
      
        }catch(error){
            console.log(error);
        }
    }
    asyncGet();
}
MyFunction()

function DeleteCompany(compid){
    console.log(compid);
    var tk = localStorage.getItem("myToken");

    const asyncPost = async () =>{
        try{
            const response = await fetch(`https://localhost:7277/api/Auth/Company/Delete/`,{
                method:'DELETE',
                headers:{
                  'Content-Type':'application/json',

                    'Accept': '*/*',

                },  body:JSON.stringify({
                    "token": tk,
                    "id": compid
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



function UpdateCompany(compid,unum){
    var tk = localStorage.getItem("myToken");

    // getting input values
    var desg  = document.getElementById(`uadddesig${unum}`).value;
    var cname = document.getElementById(`uaddcompname${unum}`).value;
    var sdate = document.getElementById(`uaddsdate${unum}`).value;
    var edate = document.getElementById(`uaddedate${unum}`).value;

    console.log(compid,unum,desg ,
        cname,
        sdate,
        edate);


        const asyncPost = async () =>{
            try{
                const response = await fetch(`https://localhost:7277/api/Auth/Company/Update/`,{
                    method:'PUT',
                    headers:{
                      'Content-Type':'application/json',
    
                        'Accept': '*/*',
    
                    },  body:JSON.stringify({
                        "token": tk,
                        "compId": compid,
                        "about": desg,
                        "compName": cname,
                        "startDate": sdate,
                        "endDate": edate
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


function AddCompany(){
    var tk = localStorage.getItem("myToken");

    // getting input values
     var desg = document.getElementById('adddesig').value;
    var cname = document.getElementById('addcompname').value;
    var sdate = document.getElementById('addsdate').value;
    var edate = document.getElementById('addedate').value;
    console.log(desg,
    cname,
    sdate,
    edate);
    const asyncPost = async () =>{
        try{
            const response = await fetch(`https://localhost:7277/api/Auth/Company/Add/`,{
                method:'POST',
                headers:{
                  'Content-Type':'application/json',

                    'Accept': '*/*',

                },  body:JSON.stringify({
                    "token": tk,
                    "about": desg,
                    "compName": cname,
                    "startDate": sdate,
                    "endDate": edate
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