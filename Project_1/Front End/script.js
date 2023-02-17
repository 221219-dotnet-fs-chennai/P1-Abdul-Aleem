// For Login
// var tokenid = {"token":"0"};
const Token = {

    token: '0',
    DataIn:'0',
 
};



function LoginFormSubmission(){
    var tokenid;
    var userName = document.getElementById("lgus").value;
    var PassWord = document.getElementById("lgps").value;


    const asyncPost = async () =>{
        try{
            const response = await fetch('https://localhost:7277/api/Auth/',{
                method:'POST',
                headers:{
                  'Content-Type':'application/json',

                    'Accept': '*/*',

                },
                body:JSON.stringify({
                    "emailID": userName,
                     "password": PassWord
                })
            });
            const data = await response.json();
            // console.log(data.token);
            // tokenid = data.token;
            checkfun(data.token)
            Token.token = data.token
            console.log(Token.token)
        }catch(error){
            console.log(error);
        }
    }
    asyncPost();
    console.log(tokenid);
}

function UserProfileMain(data){
    data[0].forEach(function(item,index){
        var div = document.createElement('div');
        div.setAttribute('class','eduindiv');

    div.innerHTML = `
    <p>Edu Id - ${item.eduId}</p>
  
    <p>Institution Name - ${item.institutionName}</p>

  <p>Course Name - ${item.courseName}</p>

  <p>Start Date - ${item.startDate}</p>

  <p>End Date - ${item.endDate}</p>

  <p>Cgpa - ${item.cgpa}</p>
    `;
    document.getElementById('edupr').appendChild(div);


    })
    console.log(data[1]);
    data[1].forEach(function(item,index){
        var div1 = document.createElement('div');
        div1.setAttribute('class','eduindiv');

    div1.innerHTML = `
    <p>Skill Id - ${item.skillId}</p>
  

  <p>Skill Name - ${item.skillName}</p>

  <p>Skill Experience - ${item.skillExperience}</p>

    `;
    document.getElementById('skillspr').appendChild(div1);


    })
    // console.log(data[2]);
    data[2].forEach(function(item,index){
        var div1 = document.createElement('div');
        div1.setAttribute('class','eduindiv');

    div1.innerHTML = `
    <p>Comp Id - ${item.compId}</p>
  

  <p>Position - ${item.about}</p>

  <p>Company Name - ${item.compName}</p>
  <p>Start Date - ${item.startDate}</p>
  <p>End Date- ${item.endDate}</p>


    `;
    document.getElementById('compspr').appendChild(div1);


    })

    console.log(data[3]);

    data[3].forEach(function(item,index){
        var div1 = document.createElement('div');
        div1.setAttribute('class','eduindiv');

    div1.innerHTML = `
    <p>Cert Id - ${item.certId}</p>
  

  <p>Certification Name - ${item.certificationName}</p>

  <p>Acquired From - ${item.acquiredFrom}</p>
  <p>Certification License No - ${item.certLicence}</p>


    `;
    document.getElementById('certspr').appendChild(div1);


    })

}



function tableCreatorProfile(data){
    let table = document.createElement('table');
let thead = document.createElement('thead');
let tbody = document.createElement('tbody');
table.appendChild(thead);
table.appendChild(tbody);
console.log(data);

// Creating and adding data to first row of the table
let row_1 = document.createElement('tr');
let heading_1 = document.createElement('th');
heading_1.innerHTML = "Edu Id";
let heading_2 = document.createElement('th');
heading_2.innerHTML = "Institution Name";
let heading_3 = document.createElement('th');
heading_3.innerHTML = "Course Name";
let heading_4 = document.createElement('th');
heading_4.innerHTML = "Start Date";
let heading_5 = document.createElement('th');
heading_5.innerHTML = "End Date";
let heading_6 = document.createElement('th');
heading_6.innerHTML = "CGPA";

row_1.appendChild(heading_1);
row_1.appendChild(heading_2);
row_1.appendChild(heading_3);
row_1.appendChild(heading_4);
row_1.appendChild(heading_5);
row_1.appendChild(heading_6);
thead.appendChild(row_1);
data[0].forEach(function(item,index){
    console.log(item.eduId,item.institutionName);
    let row_2 = document.createElement('tr');
    let row_2_data_1 = document.createElement('td');
    row_2_data_1.innerHTML = item.eduId;
    let row_2_data_2 = document.createElement('td');
    row_2_data_2.innerHTML = item.institutionName;
    let row_2_data_3 = document.createElement('td');
    row_2_data_3.innerHTML = item.courseName;
    let row_2_data_4 = document.createElement('td');
    row_2_data_4.innerHTML = item.startDate;
    let row_2_data_5 = document.createElement('td');
    row_2_data_5.innerHTML = item.endDate;
    let row_2_data_6 = document.createElement('td');
    row_2_data_6.innerHTML = item.cgpa;
   
    row_2.appendChild(row_2_data_1);
    row_2.appendChild(row_2_data_2);
    row_2.appendChild(row_2_data_3);
    row_2.appendChild(row_2_data_4);
    row_2.appendChild(row_2_data_5);
    row_2.appendChild(row_2_data_6);





    tbody.appendChild(row_2);


});
document.getElementById('profiletable').appendChild(table);

}







function checkfun(tok){
    if(tok === '0'){
        console.log("Wrong");
    }
    else{
        
        var nav1 = document.getElementById("nav1");
        nav1.remove();

        var div = document.createElement('div');
// div.setAttribute('class', 'post block bc2');
div.innerHTML = `
<nav class="navbar   navbar-expand-lg" style="background-color: rgb(255, 255, 255);" >
<div class="container-fluid navdiv">
  <a class="navbar-brand" href="#"><img src="./Components/navicon.png" alt="Logo" width="30" height="24" class="d-inline-block align-text-top"><span class="logoname">&nbsp;Trainergram</span></a>
  <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link active btt" onclick = "UserProfileMain()" aria-current="page" href="#">My Profile</a>
      </li>
      <li class="nav-item">
        <a onclick = "EducationTab()" class="nav-link active btt" aria-current="page" href="#">Education</a>
      </li>
      <li class="nav-item">
        <a class="nav-link active btt" aria-current="page" href="#">Skills</a>
      </li>
      <li class="nav-item">
        <a class="nav-link active btt" aria-current="page" href="#">Certification</a>
      </li><li class="nav-item">
        <a class="nav-link active btt" aria-current="page" href="#">Experience</a>
      </li>
     
    </ul>
    <ul class="navbar-nav ms-auto">
      <!-- <li class="nav-item">
        <a class="nav-link active btt btf" aria-current="page" href="#">Log In</a>
      </li> -->
      <li class="nav-item">
        <a class="nav-link active btt btf" aria-current="page" href="#">Log Out</a>
      </li>
      </ul>
     </div>
</div>
</nav>
`;
document.getElementById('nav2').appendChild(div);
// nav1.appendChild(div);
        // 
        const asyncGet = async () =>{
            try{
                const response = await fetch(`https://localhost:7277/api/Auth/GetAll/${tok}`,{
                    method:'GET',
                    headers:{
                      'Content-Type':'application/json',
    
                        'Accept': '*/*',
    
                    },
                  
                });
                const data = await response.json();

            //    window.open("./UserProfile.html");
            var lgform = document.getElementById("lgform");
            lgform.remove();
                // console.log(data[0]);
                // tableCreatorProfile(data);
                UserProfileMain(data);
                Token.DataIn = data;
                
                data[0].forEach(function(item,index){
                        console.log(item.eduId,item.institutionName);

                
                
                // var prtable = document.getElementById('profiletable')

                });
            }catch(error){
                console.log(error);
            }
        }
        asyncGet();
        // 
        // window.location.href="./UserProfile.html";



    }
}

// function UserProfile(){

// }



function EducationGet(){
    const asyncGet = async () =>{
        try{
            const response = await fetch(`https://localhost:7277/api/Auth/Education/${Token.token}`,{
                method:'GET',
                headers:{
                  'Content-Type':'application/json',

                    'Accept': '*/*',

                },
              
            });
            const data = await response.json();
            console.log(data);

            data.forEach(function(item,index){
                var div = document.createElement('div');
                div.setAttribute('class','eduindiv');
        
            div.innerHTML = `
            <p>Edu Id - ${item.eduId}</p>
          
            <p>Institution Name - ${item.institutionName}</p>
        
          <p>Course Name - ${item.courseName}</p>
        
          <p>Start Date - ${item.startDate}</p>
        
          <p>End Date - ${item.endDate}</p>
        
          <p>Cgpa - ${item.cgpa}</p>
            `;
            document.getElementById('edupr').appendChild(div);
        
        
            })




}catch(error){
console.log(error);
}
    }
    asyncGet();
}

function EducationTab(){
var prof = document.getElementById("allprofile");
prof.remove();
console.log("kkkkk");
EducationGet();

}







