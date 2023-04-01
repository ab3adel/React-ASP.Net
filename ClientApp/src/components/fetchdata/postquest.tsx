import React from 'react'
import {Form } from 'reactstrap'

export const PostQ =()=> {
   let formdata=new FormData();
const postQuest =(e:React.FormEvent) :void=>{
    e.preventDefault();
let form =e.currentTarget as HTMLFormElement;

    (form.childNodes).forEach(ele=>{
      
        if (ele.nodeName === "INPUT" || ele.nodeName === "TEXTAREA" || ele.nodeName === "SELECT") {
         if ((ele as HTMLInputElement).type !== "submit"){
        formdata.append((ele as HTMLInputElement).name, (ele as HTMLInputElement).value);
         }
        };
       
    })

   
if (formdata.has("Title")) {
    fetch('https://localhost:5001/api/Home/createquest',{
        method:"POST",
        body: formdata
    })
    .then(res=>console.log(res))
    .catch(err=>console.log(err))
}


}

    return (
     
          <form  onSubmit={postQuest}>
  
              <label htmlFor="Title">Title</label>
              <input type="text" name="Title" placeholder="QuestTitle"></input> 
         
              <label htmlFor="Description">Description</label>
              <textarea  name="Description" placeholder="Quest Description" spellCheck={true}></textarea> 
          
              <label htmlFor="QuestLimit">Quest Limit</label>
              <input  name="QuestLimit" placeholder="Quest Limit" type="number"></input> 
          
              <label htmlFor="Questenddate">End date</label>
              <input  name="Questenddate" placeholder="Quest Date" type="date"></input> 
         
              <label htmlFor="State">State</label>
              <select  name="State" placeholder="State" >
                  <option>emergency</option>
                  <option>aid</option>
                  </select> 
          
              <label htmlFor="UserID">State</label>
              <input  name="UserID" placeholder="user" type="number" >
                  </input> 
          
              <input type="submit" value ="submit"></input>
      
          </form>

    )
}
