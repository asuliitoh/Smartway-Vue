<script setup>

    import { ref, computed, defineModel, defineEmits } from 'vue';
    import ToDoCard from './ToDoCard.vue';
    const toDos = defineModel("toDos", {required:true, default: new Map()})
    const selectedToDo = ref(null) // selectedToDo = Objeto reactivo que almacena el ToDoItem actual seleccionado.
    const emits = defineEmits(["update", "delete"])
    const filtro = ref("ninguno")
    /**
    * Función que asigna como seleccionada una tarea.
    * @param id  ID de la tarea a seleccionar.
    */
    function selectToDo(id) {selectedToDo.value = toDos.value.get(id)}

    /**
    * Función que deselecciona la tarea actual seleccionada.
    */
    function unselectToDo() {selectedToDo.value = null;}


    /**
     * Función que actualiza una tarea. Emite un evento "update" al componente padre. 
     * @param toDo Tarea a actualizar.
     */
    function updateToDo(toDo) {
        emits("update", {id: selectedToDo.value.id, title:toDo.title, description:toDo.description, done:toDo.done, date:toDo.date})
    }

    /**
     * Función que actualiza una tarea al ser marcada. Emite un evento "update" al componente padre.
     * @param toDo Tarea a actualizar.
     */
    function checked(toDo){
        emits("update", toDo)
    }

    /**
     * Función que elimina la tarea actual seleccionada. Emite un evento "delete" al componente padre y
     * deselecciona la tarea actual.
     */
    function deleteToDo() {
        emits("delete", {id: selectedToDo.value.id, title:selectedToDo.value.title, description:selectedToDo.value.description, done:selectedToDo.value.done, date:selectedToDo.date});
        unselectToDo();
    }

    /**
     * Función que se invoca al cerrar el componente hijo ToDoCard. Deselecciona la tarea actual.
     */
    function close() {
        unselectToDo()
    }

   const orderedToDos = computed (() => {
        var entries = Array.from(toDos.value.entries())
        
        if (filtro.value === "completadas") {
            entries = entries.filter(([key, value]) => value.done)
        }

        else if (filtro.value === "nombre") {
            entries = entries.sort( ([keyA, valueA], [keyB, valueB]) => valueA.title.localeCompare(valueB.title))
        }

        return new Map(entries)
   }) 

</script>

<template>
  
    <form v-if="!selectedToDo" class="flex justify-end mb-2">
        <select class="bg-black text-white font-sembold block text-xs rounded-sm" v-model="filtro">
            <option value="ninguno">Filtrar</option>
            <option value="completadas">Tareas completadas</option>
            <option value="nombre">Nombre</option>
        </select>
    </form>

    <div v-if="!selectedToDo" v-for="[toDoID, toDoValue] in orderedToDos">
        <ul>
            <li class=" border border-gray-300 grid auto-cols-2 justify-between items-center p-4">

                <div class="col-start-1 flex items-center">
                    <input type="checkbox" class="form-checkbox h-5 w-5" v-model="toDoValue.done" @change="checked(toDos.get(toDoID))" />
                    <span class="w-100 wrap-anywhere ml-3 mr-3" :class="{'line-through' : toDoValue.done }" >{{ toDoValue.title }}</span>
                </div>
                <a class="col-start-2 w-1/3 text-xs cursor-pointer" @click="selectToDo(toDoID)">Editar</a>
            </li>
        </ul>
    </div>

    <div v-else>
        <ToDoCard v-model:title="selectedToDo.title" v-model:done="selectedToDo.done" v-model:description="selectedToDo.description" v-model:date="selectedToDo.date" @delete="deleteToDo" @update="(toDo) => updateToDo(toDo)" @close="close"></ToDoCard>
    </div>



</template>

<style scoped>


</style>