<script setup>

  //Imports necesarios
  import { onMounted, ref, computed, reactive} from 'vue';
  import ToDoCard from './ToDoCard.vue';
  import axios from 'axios';
import ToDoList from './ToDoList.vue';

  //Objetos reactivos
  const toDos = reactive(new Map()) // toDos = Map reactivo que almacena para cada ToDoItem por su ID.
  const newToDo = ref('') // newToDo = Objeto reactivo que almacena el nombre de la nueva tarea a introducir.
  const isToDosEmpty = computed(() => {return (toDos.size == 0)}) //Ref computada que devuelve true si toDos está vacia.
 
  
  /**
   * Creación del cliente HTTP mediante Axio. 
   * Se especifica como servidor a la API ASP Net.
   */
  const axiosInstance = axios.create({
    baseURL: "https://localhost:7190/",
  });

  /**
   * Una vez se ha montado el componente, se realiza una solicitud HTTP GET
   * a la API para obtener las tareas definidas.
   */
  onMounted(async () => {
    const data= await axiosInstance.get("ToDoItems/");
    
    for (let i = 0 ; i < data.data.length; i++) {
      toDos.set(data.data[i].id, 
        
        {id:data.data[i].id,
        title: data.data[i].title,
        description: data.data[i].description,
        done:data.data[i].done,
        date:data.data[i].date}
      
      )
    
      }
  })
  
/**
 * Función utilizada a la hora de crear una nueva tarea.
 * Se envía primero una solicitud HTTP POST a la API con
 * el nombre de la tarea. Una vez la API responde, se
 * introduce en el Map la tarea devuelta por la API.
 */
  function addToDo() {
    const res = ref();
    axiosInstance.post("ToDoItems/", {title: newToDo.value}).then( response => {

      toDos.set(response.data.id, 
        
      {id:response.data.id,
        title: response.data.title,
        description: response.data.description,
        done: response.data.done,
        date: response.data.date
      })

      newToDo.value = '';

    });
    
  }

  
  /**
   * Función que elimina una tarea. Para ello, envía una solicitud
   * HTTP DELETE a la API, y si no hay errores, elimina localmente.
   */
  function deleteToDo(toDo) {

    axiosInstance.delete(`ToDoItems/${toDo.id}`).then(() => {
      toDos.delete(toDo.id);
     
    })    
  }

  /**
   * Método que actualiza una tarea. Para ello, envía una solicitud HTTP PUT a
   * la API, y si no hay errores, actualiza localmente.
   * TODO: Revisar método. Actualmente funciona, pero se llama repetidas veces.
   */
  function updateToDo(toDo){

    axiosInstance.put(`ToDoItems/${toDo.id}`, {id: toDo.id, title:toDo.title,
      description: toDo.description, date: toDo.date, done: toDo.done}).then(toDos.set(toDo.id, toDo))
    }


</script>

<template>
  
      <div class="p-10 grid grid-rows-[auto_1fr] gap-x-4 border border-gray-300">
        <p class="text-left font-bold text-xl pb-5">ToDoList App</p>

        <form @submit.prevent="addToDo">   
          <label for="search" class="mb-2 text-sm font-medium text-gray-900"></label>
          <div class="flex flex-row border border-gray-300 rounded-lg bg-gray-50 p-2">
              <input type="text" id="search" v-model="newToDo" class="block w-full text-sm text-gray-900" placeholder="Introduce una tarea" />
              <button type="button" @click="addToDo" class="text-white bg-black self-center font-medium rounded-lg text-sm px-4 py-2">Añadir</button>
          </div>
        </form>

        <div v-if="!isToDosEmpty" class="mt-10 col-span-full">
           <ToDoList v-bind:toDos="toDos" @update="(toDo) => updateToDo(toDo)" @delete="(toDo) => deleteToDo(toDo)"></ToDoList>
        </div>
      </div>     
    
</template>


<style scoped>
</style>