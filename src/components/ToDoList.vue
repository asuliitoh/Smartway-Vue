<script setup>

import { ref, watch, defineModel, defineEmits } from 'vue';
import ToDoCard from './ToDoCard.vue';
const toDos = defineModel("toDos", {required:true, default: new Map()})
const selectedToDo = ref(null) // selectedToDo = Objeto reactivo que almacena el ToDoItem actual seleccionado.
const emits = defineEmits(["update", "delete"])

/**
   * Función que asigna como seleccionada una tarea.
   * @param id  ID de la tarea a seleccionar.
   */
  function selectToDo(id) {selectedToDo.value = toDos.value.get(id); console.log(selectedToDo.value)}

  /**
   * Función que deselecciona la tarea actual seleccionada.
   */
  function unselectToDo() {selectedToDo.value = null;}


  function updateToDo(toDo) {
    emits("update", {id: selectedToDo.value.id, title:toDo.title, description:toDo.description, done:toDo.done, date:toDo.date})
  }

  function checked(toDo){
    emits("update", toDo)
  }

  function deleteToDo() {
    emits("delete", {id: selectedToDo.value.id, title:selectedToDo.value.title, description:selectedToDo.value.description, done:selectedToDo.value.done, date:selectedToDo.date});
    unselectToDo();
  }

  function close() {
    unselectToDo()
  }

</script>

<template>

    <div v-if="!selectedToDo" v-for="[toDoID, toDoValue] in toDos">
        <ul>
            <li class=" border border-gray-300 flex justify-between items-center p-4">
                <div class="flex items-center">
                <input type="checkbox" class="form-checkbox h-5 w-5" v-model="toDoValue.done" @change="checked(toDos.get(toDoID))" />
                <span class="ml-3" :class="{'line-through' : toDoValue.done }" >{{ toDoValue.title }}</span>
                </div>
                <a class="text-xs cursor-pointer" @click="selectToDo(toDoID)">Editar</a>
            </li>
        </ul>
    </div>

    <div v-else>

        <ToDoCard v-model:title="selectedToDo.title" v-model:done="selectedToDo.done" v-model:description="selectedToDo.description" v-model:date="selectedToDo.date" @delete="deleteToDo" @update="(toDo) => updateToDo(toDo)" @close="close"></ToDoCard>

    </div>



</template>

<style scoped></style>