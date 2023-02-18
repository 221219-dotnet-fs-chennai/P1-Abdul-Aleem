// function LoginFormSubmission(){
//     var tokenid;
//     var userName = document.getElementById("lgus").value;
//     var PassWord = document.getElementById("lgps").value;


//     const asyncPost = async () =>{
//         try{
//             const response = await fetch('https://localhost:7277/api/Auth/',{
//                 method:'POST',
//                 headers:{
//                   'Content-Type':'application/json',

//                     'Accept': '*/*',

//                 },
//                 body:JSON.stringify({
//                     "emailID": userName,
//                      "password": PassWord
//                 })
//             });
//             const data = await response.json();
//             // console.log(data.token);
//             // tokenid = data.token;
//             checkfun(data.token)
//             Token.token = data.token
//             console.log(Token.token)
//         }catch(error){
//             console.log(error);
//         }
//     }
//     asyncPost();
//     console.log(tokenid);
// }



function LoginSubmission(){
    var usname = document.getElementById("usname").value;
    var pass = document.getElementById("pass").value;
    // console.log(usname)
    // console.log(pass)
    const asyncPost = async () =>{
                try{
                    const response = await fetch('https://localhost:7277/api/Auth/',{
                        method:'POST',
                        headers:{
                          'Content-Type':'application/json',
        
                            'Accept': '*/*',
        
                        },
                        body:JSON.stringify({
                            "emailID": usname,
                             "password": pass,
                        })
                    });
                    const data = await response.json();
                    console.log(data.token)
                    if(data.token !=='0'){
                        localStorage.setItem("myToken",data.token);
                        window.location.replace("./MyProfile.html");

                    }
                    else{
                        var q = document.getElementById("loginwarning");
                        var div = document.createElement('div');
                        // div.setAttribute('class', 'post block bc2');
                        div.innerHTML = `<div class="alert alert-warning" role="alert">
                        Incorrect Email Id or Password
                      </div>`;
                        q.appendChild(div);
                    }
                }catch(error){
                    console.log(error);
                }
            }
            asyncPost();

}