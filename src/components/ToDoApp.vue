<script setup>
  import { ref } from 'vue';
  import ToDoCard from './ToDoCard.vue';

  const toDos = ref([ {title: 'Terminar Piolify', done: false}, {title:'Terminar AppChat', done: false}])
  const selectedToDo = ref(null)

  const nuevaTarea = ref('')
  
  function addToDo() {
    toDos.value.push({title: nuevaTarea.value, done:false});
    nuevaTarea.value='';
  }

  function selectToDo(toDo) {
    selectedToDo.value = toDo
  }

  function unselectToDo() {
    selectedToDo.value = null
  }

  function deleteToDo() {
    toDos.value.splice(toDos.value.findIndex(selectToDo), 1)
    unselectToDo()
  }

</script>

<template>
    
    <div v-if="!selectedToDo" class="grid grid-rows-[auto_1fr] gap-x-4 ">
        
        
        <div class="row-start-1 col-span-full flex flex-row">

          <!--
            <h2 class="row-start-1 col-start-1 text-5xl font-semibold pr-10 ">Introduce una tarea:</h2>
            <form @submit.prevent="addToDo" class="row-start-1 col-start-2 flex items-center" >
                <input class="border-2 rounded-lg text-xs h-full" v-model="nuevaTarea" placeholder="Nombre de la tarea">
            </form>
          -->
        </div>
        

        <div class="col-span-full grid auto-cols-3 auto-rows-2 border border-gray-300 rounded-xl [&>*:nth-last-child(n+4)]:border-b [&>:not(:nth-child(3n))]:border-r [&>*]:border-gray-300">
            <h3 class="font-bold row-start-1 col-start-1"> Nombre de la tarea</h3>
            <h3 class="font-bold row-start-1 col-start-2"> Estado de la tarea</h3>
            <h3 class="font-bold row-start-1 col-start-3">Acciones</h3>
            <template v-for="toDo in toDos">
                <p class="col-start-1 font-semibold p-2"> {{ toDo.title }} </p>
                <p class="text-green-500 font-semibold col-start-2" v-if="toDo.done">Hecho</p>
                 <p class="text-red-500 font-semibold col-start-2" v-else>No hecho</p>      
                <div id="botones" class="col-start-3 flex flex-row">
                    <button @click="toDo.done = !toDo.done" type="button" class=" font-semibold bg-white border-2 rounded-lg pl-2 pr-2 m-1">Marcar como completada</button>
                    <button @click="selectToDo(toDo)" type="button" class="font-semibold bg-white border-2 rounded-lg m-1 pl-2 pr-2">Editar</button>
                </div>  
            </template>

        </div>
        <button type="button" class="bg-white border border-t-0 border-gray-300 hover:bg-gray-100 rounded-lg p-2 font-semibold ">Introducir Tarea</button>
    </div>   

    <div v-else class="p-10 flex flex-row justify-center items-center">
      <img @click="unselectToDo" class="cursor-pointer pr-5" src="/src/components/icons/left-arrow.png" alt="Volver"/>
      <ToDoCard v-model:title="selectedToDo.title" v-model:done="selectedToDo.done" @delete="deleteToDo"></ToDoCard>
      
    </div>
    
</template>


<style scoped>
</style>