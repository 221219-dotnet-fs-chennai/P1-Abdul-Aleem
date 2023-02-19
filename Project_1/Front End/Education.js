function logout(){
    localStorage.removeItem("myToken");
}
function MyFunction(){
    var tk = localStorage.getItem("myToken");
    console.log(tk);


    function EducationProfile(data){
        let count = 11;
        data[0].forEach(function(item,index){
            count +=1;
            let startDate = item.startDate;
            let endDate  = item.endDate;


            var dive = document.createElement('div');
            dive.setAttribute('class','row');
            
            dive.innerHTML = `
            <div class="col-10" >
          <div class="educol1">
            <h5>${item.institutionName}</h5>
            <h6>${item.courseName}</h6>
            <p class="cgpa">CGPA - ${item.cgpa}</p>
            <!-- <div class="cgpa">
              CGPA - 9.0
            </div> -->

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
                      <input type="text" placeholder = "Institution Name"  value=${item.institutionName} id="uaddinsname${count}"/>
                      <input type="text" placeholder="Course" value =${item.courseName}  id = "uaddconame${count}"/>
                      <input type="text" placeholder="CGPA" value = ${item.cgpa} id="uaddcgpa${count}"/>
                      <input type="text" placeholder="Start Date" value =${startDate.substr(0,10)}  id="uaddsdate${count}"/>
                      <input type="text" placeholder="End Date" value =${endDate.substr(0,10)}  id="uaddedate${count}"/>
            
            
                      <!-- <p class="message" >Not registered? <a href="#">Create an account</a></p> -->
                    </form>
                    <button class="frbut" onclick="UpdateEducation(${item.eduId},${count})">Update</button>
            
                  </div>
                  </div>
              <div class="offcanvas-body">
                ...
              </div>
            </div>
           <!-- <a class="aic" href=""> <i style="font-size: 1.2rem;" class="bi  bi-pencil-fill  edicon"></i></a> -->
            <br>
            <br>
            <a  class="aic" onclick="DeleteEducation(${item.eduId})" href="#1"><i style="font-size: 1.2rem;" class="bi bi-trash3-fill delicon"></i></a>
        </div>
      </div>
            `;

            document.getElementById('edubody').appendChild(dive);
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

            EducationProfile(data);
          
      
        }catch(error){
            console.log(error);
        }
    }
    asyncGet();

}
MyFunction()


function DeleteEducation(eduid){
    console.log(eduid);
    var tk = localStorage.getItem("myToken");

    const asyncPost = async () =>{
        try{
            const response = await fetch(`https://localhost:7277/api/Auth/Education/Delete`,{
                method:'DELETE',
                headers:{
                  'Content-Type':'application/json',

                    'Accept': '*/*',

                },  body:JSON.stringify({
                    "token": tk,
                    "id": eduid
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

// {
    // "token": "H1B3UM3O9GP3I1TW",
    // "eduId": 3,
    // "institutionName": "string",
    // "courseName": "string",
    // "startDate": "2023-02-07T19:10:37.519Z",
    // "endDate": "2023-02-07T19:10:37.519Z",
    // "cgpa": "string"
//   }

function UpdateEducation(eduid,unum){
    var tk      = localStorage.getItem("myToken");
    var insname = document.getElementById(`uaddinsname${unum}`).value;
    var cname   = document.getElementById(`uaddconame${unum}`).value;
    var cgpa    = document.getElementById(`uaddcgpa${unum}`).value;
    var sdate  = document.getElementById(`uaddsdate${unum}`).value;
    var edate   = document.getElementById(`uaddedate${unum}`).value;
// console.log(eduid,tk,     
//     insname,
//     cname  ,
//     cgpa   ,
//     sdate  ,
//     edate  )

    const asyncPost = async () =>{
        try{
            const response = await fetch(`https://localhost:7277/api/Auth/Education/Update/`,{
                method:'PUT',
                headers:{
                  'Content-Type':'application/json',

                    'Accept': '*/*',

                },  body:JSON.stringify({
                    "token": tk,
                    "eduId": eduid,
                    "institutionName": insname,
                    "courseName": cname,
                    "startDate": sdate,
                    "endDate": edate,
                    "cgpa": cgpa
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




function AddEducation(){
    var tk = localStorage.getItem("myToken");

    // getting input values
    var insname = document.getElementById('addinsname').value;
    var cname = document.getElementById('addconame').value;
    var cgpa = document.getElementById('addcgpa').value;
    var sdate = document.getElementById('addsdate').value;
    var edate = document.getElementById('addedate').value;

console.log(insname,
    cname,
    cgpa ,
    sdate,
    edate);
    const asyncPost = async () =>{
        try{
            const response = await fetch(`https://localhost:7277/api/Auth/Education/Add`,{
                method:'POST',
                headers:{
                  'Content-Type':'application/json',

                    'Accept': '*/*',

                },  body:JSON.stringify({
                    "token": tk,
                    "institutionName": insname,
                    "courseName": cname,
                    "startDate": sdate,
                    "endDate": edate,
                    "cgpa": cgpa
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