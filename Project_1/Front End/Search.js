function ButtonFunction(){

    var radio1 = document.getElementById("flexSwitchCheckDefault1").checked;
    var radio2 = document.getElementById("flexSwitchCheckDefault2").checked;
    var radio3 = document.getElementById("flexSwitchCheckDefault3").checked;

    if(radio1){
        document.getElementById("flexSwitchCheckDefault2").checked = false;  
        document.getElementById("flexSwitchCheckDefault3").checked = false;  

    }
    if(radio2){
        document.getElementById("flexSwitchCheckDefault1").checked = false;  
        document.getElementById("flexSwitchCheckDefault3").checked = false;  
    }
    if(radio3){
        document.getElementById("flexSwitchCheckDefault1").checked = false;  
        document.getElementById("flexSwitchCheckDefault2").checked = false;  
    }
}

function EnterSearch(){
    var searchitem = document.getElementById("searchkey").value;
    var radio1 = document.getElementById("flexSwitchCheckDefault1").checked;
    var radio2 = document.getElementById("flexSwitchCheckDefault2").checked;
    var radio3 = document.getElementById("flexSwitchCheckDefault3").checked;
    console.log(searchitem,radio1,radio2,radio3);


    function SearchByCity(data){
        
        var divr = document.createElement('div');
        divr.setAttribute('class','serbody');   
        divr.setAttribute('id','serb');

        divr.innerHTML = `
        <div class="cityres">
        <h4>Results based on City :</h4>
        <div class="res1">
           
    <div class="container-fluid	" id="newrowc">

    </div>
    </div>
    </div>

        `;
        document.getElementById('serb1').appendChild(divr);

        // data.foEach(function(item,index){
            for(const val in data){
                console.log(data[val]);
       
            var divc = document.createElement('div');
            divc.setAttribute('class','row newr');
            divc.innerHTML = `
            <div class="col">
            <div class="fnln">
            <h5>${data[val].firstName}</h5>
            &nbsp;
            <h5>${data[val].lastName}</h5>
            </div>
            <h6>${data[val].city}</h6>
            <h6>${data[val].phoneNo}</h6>
            <h6>${data[val].emailId}</h6>

        </div>
            `;
            
            document.getElementById('newrowc').appendChild(divc);
    };
}

function SearchBySkill(data){
        
    var divr = document.createElement('div');
    divr.setAttribute('class','serbody');   
        divr.setAttribute('id','serb');

    divr.innerHTML = `
    <div class="cityres">
    <h4>Results based on Skills :</h4>
    <div class="res1">
       
<div class="container-fluid	" id="newrowc">

</div>
</div>
</div>

    `;
    document.getElementById('serb1').appendChild(divr);

    // data.foEach(function(item,index){
        for(const val in data){
            console.log(data[val]);
   
        var divc = document.createElement('div');
        divc.setAttribute('class','row newr');
        divc.innerHTML = `
        <div class="col">
        <div class="fnln">
        <h5>${data[val].firstName}</h5>
        &nbsp;
        <h5>${data[val].lastName}</h5>
        </div>
        <h6>${data[val].city}</h6>
        <h6>${data[val].phoneNo}</h6>
        <h6>${data[val].emailId}</h6>

    </div>
        `;
        
        document.getElementById('newrowc').appendChild(divc);
};
}

function SearchByCertification(data){
        
    var divr = document.createElement('div');
    divr.setAttribute('class','serbody');   
        divr.setAttribute('id','serb');


    divr.innerHTML = `
    <div class="cityres">
    <h4>Results based on Certification :</h4>
    <div class="res1">
       
<div class="container-fluid	" id="newrowc">

</div>
</div>
</div>

    `;
    document.getElementById('serb1').appendChild(divr);

    // data.foEach(function(item,index){
        for(const val in data){
            console.log(data[val]);
   
        var divc = document.createElement('div');
        divc.setAttribute('class','row newr');
        divc.innerHTML = `
        <div class="col">
        <div class="fnln">
        <h5>${data[val].firstName}</h5>
        &nbsp;
        <h5>${data[val].lastName}</h5>
        </div>
        <h6>${data[val].city}</h6>
        <h6>${data[val].phoneNo}</h6>
        <h6>${data[val].emailId}</h6>

    </div>
        `;
        
        document.getElementById('newrowc').appendChild(divc);
};
}







    if(radio1){
        var hh = document.getElementById('serb');
        if(hh){
            hh.remove();

        }
        const asyncGet = async () =>{
            try{
                const response = await fetch(`https://localhost:7277/api/Trainer/City/${searchitem}`,{
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
                // SkillProfile(data);
                // CompanyProfile(data);
                // CertificationProfile(data);
                SearchByCity(data);
          
            }catch(error){
                console.log(error);
            }
        }
        asyncGet();
    }

    if(radio2){
        var hh = document.getElementById('serb');
        if(hh){
            hh.remove();

        }
        const asyncGet = async () =>{
            try{
                const response = await fetch(`https://localhost:7277/api/Trainer/Skill/${searchitem}`,{
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
                // SkillProfile(data);
                // CompanyProfile(data);
                // CertificationProfile(data);
                // SearchByCity(data);
                SearchBySkill(data);
            }catch(error){
                console.log(error);
            }
        }
        asyncGet();

    }

    if(radio3){
        var hh = document.getElementById('serb');
        if(hh){
            hh.remove();

        }
        const asyncGet = async () =>{
            try{
                const response = await fetch(`https://localhost:7277/api/Trainer/Certification/${searchitem}`,{
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
                // SkillProfile(data);
                // CompanyProfile(data);
                // CertificationProfile(data);
                // SearchByCity(data);
                SearchByCertification(data);
            }catch(error){
                console.log(error);
            }
        }
        asyncGet();
    }
}