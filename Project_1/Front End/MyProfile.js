function MyFunction() {
    var tk = localStorage.getItem("myToken");
    console.log(tk);

    function BodyProfile(data){
        data[4].forEach(function(item,index){
            
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

      
        }catch(error){
            console.log(error);
        }
    }
    asyncGet();







}
MyFunction();