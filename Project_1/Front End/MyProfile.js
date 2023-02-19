function logout(){
  localStorage.removeItem("myToken");
}
function MyFunction() {
    var tk = localStorage.getItem("myToken");
    console.log(tk);

    // User details section
    function BodyProfile(data){
        data[4].forEach(function(item,index){
            // var prb = document.getElementById('prb');
            // var div = document.createElement('div');
            //     div.setAttribute('class','eduindiv');
            var divb = document.createElement('div');
            divb.innerHTML = `
            <div class="row">
        <div class="col">
          <img class="dpimg" src="./Components/dp.jpg" alt="img not found">
          <div class="fname">
            <h4 class="ush4">${item.firstName}</h4>
            &nbsp;
            <h4 class="ush4">${item.lastName}</h4>

          </div>
          <h6 class="city">${item.city}</h6>

        </div>
        <div class="col emailcol">
          <div class="emailphoneno">
            <h6>${item.emailId}</h6>
            <h6>${item.phoneNo}</h6>

          </div>
        </div>
      </div>
            
            `;
            document.getElementById('profilebody').appendChild(divb);
        })

    }

    // User Education section

    function EducationProfile(data){
        data[0].forEach(function(item,index){
            let startDate = item.startDate;
            let endDate  = item.endDate;


            var dive = document.createElement('div');
            dive.setAttribute('class','row');
            dive.innerHTML = `
            <div class="col">
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
            `;

            document.getElementById('edubody').appendChild(dive);
        })
    }

    function SkillProfile(data){
        data[1].forEach(function(item,index){
            var divs = document.createElement('div');
            divs.setAttribute('class','row');
            divs.innerHTML = `
            <div class="col">
            <div class="educol1">
              <h5>${item.skillName}</h5>
              <p class="cgpa skillend">Experience - ${item.skillExperience} Months</p>
              
            </div>
          </div>
            `;
            document.getElementById('skillbody').appendChild(divs);

        });
    }

    function CompanyProfile(data){
        data[2].forEach(function(item,index){
            let startDate = item.startDate;
            let endDate  = item.endDate;
            var divc = document.createElement('div');
            divc.setAttribute('class','row');
            divc.innerHTML = `
            <div class="col">
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
            `;
            document.getElementById('compbody').appendChild(divc);
        });
    }

    function CertificationProfile(data){
        data[3].forEach(function(item,index){
            var divce = document.createElement('div');
            divce.setAttribute('class','row');
            divce.innerHTML = `
            <div class="col">
                <div class="educol1">
                  <h5>${item.certificationName}</h5>
                  <h6>${item.acquiredFrom}</h6>
                  <p class="cgpa skillend">License No - ${item.certLicence}</p>
                
                </div>
              </div>
            `;
            document.getElementById('certbody').appendChild(divce);
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

            BodyProfile(data);
            EducationProfile(data);
            SkillProfile(data);
            CompanyProfile(data);
            CertificationProfile(data);
      
        }catch(error){
            console.log(error);
        }
    }
    asyncGet();







}
MyFunction();