import React,{useEffect,useState} from 'react'
import {Form,Input } from 'reactstrap'
import {iquest} from '../interfaces'
import {useLocation} from 'react-router-dom'

interface istate{id:number}
export const UpdateQuest =()=>{

   const [Quest,setQuest]= useState<iquest>()
  
   let {state} = useLocation<{id:number}>();
   const [id ,setId]=useState<number>(state.id);
   let formdata =new FormData();
useEffect(()=>{

 setId(state.id)
     fetchQuest();
    
},[])
const fetchQuest =()=>{
    fetch (`https://localhost:5001/api/Home/updatequest/${id}`,{
        method:"GET",  
        headers:{"Access-Control-Allow-Origin":"*"}

  })
  .then(res=>res.json())
  .then((jsn)=>setQuest(jsn))
  .catch(err=>console.log(err))
}
const putQuest =(e:React.FormEvent) :void=>{
    e.preventDefault();
 
let form =e.currentTarget as HTMLFormElement;
         formdata.append("QuestID",id.toString()); 
    (form.childNodes).forEach(ele=>{
      
        if (ele.nodeName === "INPUT" || ele.nodeName === "TEXTAREA" || ele.nodeName === "SELECT") {
         if ((ele as HTMLInputElement).type !== "submit"){
        formdata.append((ele as HTMLInputElement).name, (ele as HTMLInputElement).value);
         }
        };
       
    })
    if (formdata.has("Title")) {
        fetch(`https://localhost:5001/api/Home/updatequest/${id}`,{
            method:"PUT",
            body: formdata
        })
        .then(res=>console.log(res))
        .catch(err=>console.log(err))
    }

}



    return (
        <React.Fragment>
        {id !==0 ?
          Quest?
         
        <form  onSubmit={putQuest}>
  
        <label htmlFor="Title">Title</label>
        <input type="text" name="Title" placeholder="QuestTitle" defaultValue ={Quest?.title}></input> 
   
        <label htmlFor="Description">Description</label>
        <textarea defaultValue={Quest?.content}  name="Description" placeholder="Quest Description" spellCheck={true}></textarea> 
    
        <label htmlFor="QuestLimit">Quest Limit</label>
        <input defaultValue={Quest?.limit} name="QuestLimit" placeholder="Quest Limit" type="number"></input> 
    
        <label htmlFor="Questenddate">End date</label>
        <input  name="Questenddate" 

         placeholder="Quest Date" type="date"></input> 
   
        <label htmlFor="State">State</label>
        <select defaultValue={Quest?.state} name="State" placeholder="State" >
            <option>emergency</option>
            <option>aid</option>
            </select> 
    
        <label htmlFor="UserID">State</label>
        <input defaultValue={Quest?.userID} name="UserID" placeholder="user" type="number" >
            </input> 
    
        <input type="submit" value ="submit"></input>

    </form>:"it is loading "
       :"wait just a moment please" }
       </React.Fragment>
    )
}