<script setup>
import { ref } from 'vue';

  const toDos = ref([ {message: 'Terminar Piolify', done: false}, {message:'Terminar AppChat', done: false}])
  const selectedToDo = ref(null)

  const nuevaTarea = ref('')
  function addToDo() {
    tareas.value.push({message: nuevaTarea.value, done:false});
    nuevaTarea.value='';
  }

  function selectToDo(toDo) {
    selectedToDo.value = toDo
  }

</script>

<template>

    <div v-if="!selectedToDo" class="grid grid-rows-[auto_1fr] grid-cols-[auto_1fr] gap-x-4 gap-y-20 border-2 bg-gray-100 rounded-xl p-10 m-20">
        
        <div class="row-start-1 col-span-full flex flex-row justify-center">

            <h2 class="row-start-1 col-start-1 text-5xl font-semibold pr-10 ">Introduce una tarea:</h2>
            <form @submit.prevent="addToDo" class="row-start-1 col-start-2 flex items-center" >
                <input class="border-2 rounded-lg text-xs h-full" v-model="nuevaTarea" placeholder="Nombre de la tarea">
            </form>

        </div>

            
            
        <div class="col-span-full grid grid-cols-3 auto-rows-2 self-start [&>*]:border [&>*]:border-black">
            <h3 class="font-bold row-start-1 col-start-1"> Nombre de la tarea</h3>
            <h3 class="font-bold row-start-1 col-start-2"> Estado de la tarea</h3>
            <h3 class="font-bold row-start-1 col-start-3">Acciones</h3>
            <template v-for="toDo in toDos">
                <p class="col-start-1 font-semibold p-2"> {{ toDo.message }} </p>
                <p class="text-green-500 font-semibold col-start-2" v-if="toDo.done">Hecha</p>
                <p class="text-red-500 font-semibold col-start-2" v-else>No hecha</p>
                
                <div id="botones" class="col-start-3 flex flex-row">
                    <button @click="toDo.done = !toDo.done" type="button" class=" font-semibold bg-white border-2 rounded-lg pl-2 pr-2 m-1">Marcar como completada</button>
                    <button @click="selectToDo(toDo)" type="button" class="font-semibold bg-white border-2 rounded-lg m-1 pl-2 pr-2">Editar</button>
                </div>

                
                
            </template>

        </div>
            
    </div>   

    <div v-else class="grid grid-rows-[auto_1fr] grid-cols-[auto_1fr] gap-x-4 gap-y-20 border-2 bg-gray-100 rounded-xl p-10 m-20">
      <!--TODO: Crear componente ToDoCard para mostrar una tarea a mas detalle -->
        Nombre de la tarea: {{ selectedToDo.message }}
       <br>
       Hecho: {{ selectedToDo.done }}
    </div>
    
</template>


<style scoped>
</style>