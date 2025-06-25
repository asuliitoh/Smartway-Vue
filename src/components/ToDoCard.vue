<script setup>
    import { ref, defineProps} from 'vue';

    //Objetos Reactivos
    const editar = ref(false) //Utilizado para permitir el modo edición.
    const props = defineProps({ //Propiedades del componente.
        
        title: {
            type: String,
            required: true
        },

        date: {
            type: String,
            required: true,
        },

        description: {
            type: String,
            required: false
        },

        done: {
            type: Boolean,
            required: true,
        }

    })

    //Tarea actual. Esta copia permite actualizar sus valores con el modo edición.
    const toDo = ref({title: props.title, date: props.date, description: props.description, done: props.done})

    //Eventos definidos del componente.
    const emits = defineEmits(["delete", "update", "close"])



    /**
     * Función que emite el evento "delete" a su componente padre.
     */
    function deleteToDo() {
        emits("delete")
    }

    /**
     * Función que emite el evento "update" a su componente padre. Si no se ha editado ningun campo, no se emite.
     */
    function updateToDo() {

        if (props.title !== toDo.value.title || props.description !== toDo.value.description || props.done !== toDo.value.done) {

            emits("update", {title: toDo.value.title, date: props.date, description: toDo.value.description, done:toDo.value.done})

        }
        editar.value = !editar.value

    }

    /**
     * Función que emite el evento "close" a su componente padre. Si se está en modo edición, no es posible editar.
     */
    function close() {
        if (editar.value === false) {
            emits("close")
        }
    }

</script>

<template>
    <div v-if="!editar" class="flex justify-end pb-2"><img src="/src/components/icons/close.png" :class = "{'cursor-pointer': !editar}" alt="Cerrar" @click="close"></div>
    
    <div id="card" class="tracking-tight border-gray-300 border-2 rounded-xl grid auto-rows-5 grid-cols-2 items-center">
    
        <h2 class="h-full bg-gray-100 border-b-2 border-r-2 border-gray-300 pl-2 font-semibold text-base">Nombre de la tarea</h2>
        <p v-if="!editar" class="h-full bg-gray-100 pl-2 border-b-2 border-gray-300 font-normal text-base"> {{ toDo.title }}</p>
        <textarea v-else v-model="toDo.title" class="resize-none h-full bg-gray-100 pl-2 border-b-2 border-gray-300 font-normal text-base"></textarea>

        <h2 class="h-full bg-white border-b-2 border-r-2 border-gray-300 pl-2 font-semibold text-base">Descripción de la tarea</h2>
        <p v-if="!editar" class="h-full bg-white border-b-2 pl-2 border-gray-300 text-base">{{ toDo.description }}</p>
        <textarea v-else v-model="toDo.description" class="resize-none h-full bg-white border-b-2 pl-2 border-gray-300 text-base"></textarea>

        <h2 class="h-full bg-gray-100 border-b-2 border-r-2 border-gray-300 pl-2 font-semibold text-base">Fecha de creación</h2>
        <p class="h-full bg-gray-100 border-b-2 pl-2 border-r-2 border-gray-300 text-base"> {{ new Date(toDo.date).toLocaleString() }} </p>

        <h2 class="h-full bg-white border-b-2 border-r-2 border-gray-300 pl-2 font-semibold text-base">Estado</h2>
        <p v-if="!editar" class="h-full bg-white border-b-2 pl-2 border-gray-300 text-base"> 
            <span v-if="toDo.done">Hecho</span>
            <span v-else>No Hecho</span>
        </p>
        <select v-else v-model="toDo.done" class="h-full bg-white border-b-2 pl-2 border-gray-300 text-base">
            <option :value="true">Hecho</option>
            <option :value="false">No hecho</option>
        </select>

        <div class="h-full bg-gray-100 col-span-full flex justify-around text-base p-2">
            <button v-if="!editar" type="button" @click="editar = !editar" class="bg-white border-2 rounded-lg border-gray-300 p-2 font-semibold">Modo Edición</button>
            <button v-else type="button" @click="updateToDo" class="bg-white border-2 rounded-lg border-gray-300 p-2 font-semibold">Modo Solo Lectura</button>
            <button type="button" @click="deleteToDo" class="bg-white border-2 rounded-lg border-gray-300 p-2 font-semibold">Eliminar</button>
        </div>

    </div>

</template>

<style scoped>

</style>
