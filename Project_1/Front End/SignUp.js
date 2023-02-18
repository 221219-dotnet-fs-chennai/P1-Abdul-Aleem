function LoginFormSubmission(){
    var fname  = document.getElementById('fname').value;
    var lname  = document.getElementById('lname').value;
    var email  = document.getElementById('email').value;
     var pass  = document.getElementById('pass').value;
     var phno  = document.getElementById('phno').value;
     var city  = document.getElementById('city').value;
console.log(fname,
    lname,
    email,
    pass ,
    phno ,
    city );

    const asyncPost = async () =>{
                try{
                    const response = await fetch(`https://localhost:7277/api/Auth/SignUp/`,{
                        method:'POST',
                        headers:{
                          'Content-Type':'application/json',
        
                            'Accept': '*/*',
        
                        },  body:JSON.stringify({
                            "firstName": fname,
                            "lastName": lname,
                            "emailId": email,
                            "password": pass,
                            "phoneNo": phno,
                            "city": city
                        })
                      
                    });
                    const data = await response.json();
                    console.log(data);
                    if(data.status === 400){
                        alert("Please fill the form correctly");
                    }
                    else{
                    alert("User Created successfully");
                    window.location.replace("./Login.html");

                    
                    }
                   
              
                }catch(error){
                    console.log(error);
                    alert(error);
                }
            }
            asyncPost();

}



// function AddCompany(){
//     var tk = localStorage.getItem("myToken");

//     // getting input values
//      var desg = document.getElementById('adddesig').value;
//     var cname = document.getElementById('addcompname').value;
//     var sdate = document.getElementById('addsdate').value;
//     var edate = document.getElementById('addedate').value;
//     console.log(desg,
//     cname,
//     sdate,
//     edate);
//     const asyncPost = async () =>{
//         try{
//             const response = await fetch(`https://localhost:7277/api/Auth/Company/Add/`,{
//                 method:'POST',
//                 headers:{
//                   'Content-Type':'application/json',

//                     'Accept': '*/*',

//                 },  body:JSON.stringify({
//                     "token": tk,
//                     "about": desg,
//                     "compName": cname,
//                     "startDate": sdate,
//                     "endDate": edate
//                 })
              
//             });
//             const data = await response.json();
//             console.log(data);
//             if(data.status === 400){
//                 alert("Please fill the form correctly");
//             }
//             else{
//             alert("Added successfully");
//             location.reload();
//             }
           
      
//         }catch(error){
//             console.log(error);
//             alert(error);
//         }
//     }
//     asyncPost();
// }