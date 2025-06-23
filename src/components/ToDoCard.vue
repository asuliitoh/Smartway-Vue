<script setup>

import { ref } from 'vue';


const editar = ref(false)
const date = defineModel("date", {required: true, default: "no tiene fecha"})
const title = defineModel("title", {required: true, default: "No posee nombre" })
const description = defineModel("description", {required: false, default:"No dispone de descripción"})
const done = defineModel("done", {required: true, default:false})

const emits = defineEmits(["delete"])

function deleteToDo() {
    emits("delete")
}

</script>

<template>

    <div id="card" class="tracking-tight border-gray-300 border-2 rounded-xl grid auto-rows-5 grid-cols-2 items-center">

        <h2 class="h-full bg-gray-100 border-b-2 border-r-2 border-gray-300 pl-2 font-semibold text-base">Nombre de la tarea</h2>
        <p v-if="!editar" class="h-full bg-gray-100 pl-2 border-b-2 border-gray-300 font-normal text-base"> {{ title }}</p>
        <textarea v-else v-model="title" class="resize-none h-full bg-gray-100 pl-2 border-b-2 border-gray-300 font-normal text-base"></textarea>

        <h2 class="h-full bg-white border-b-2 border-r-2 border-gray-300 pl-2 font-semibold text-base">Descripción de la tarea</h2>
        <p v-if="!editar" class="h-full bg-white border-b-2 pl-2 border-gray-300 text-base">{{ description }}</p>
        <textarea v-else v-model="description" class="resize-none h-full bg-white border-b-2 pl-2 border-gray-300 text-base"></textarea>

        <h2 class="h-full bg-gray-100 border-b-2 border-r-2 border-gray-300 pl-2 font-semibold text-base">Fecha de creación</h2>
        <p class="h-full bg-gray-100 border-b-2 pl-2 border-r-2 border-gray-300 text-base"> {{ new Date(date).toLocaleString() }} </p>

        <h2 class="h-full bg-white border-b-2 border-r-2 border-gray-300 pl-2 font-semibold text-base">Estado</h2>
        <p v-if="!editar" class="h-full bg-white border-b-2 pl-2 border-gray-300 text-base"> 
            <span v-if="done">Hecho</span>
            <span v-else>No Hecho</span>
        </p>
        <select v-else v-model="done" class="h-full bg-white border-b-2 pl-2 border-gray-300 text-base">
            <option :value="true">Hecho</option>
            <option :value="false">No hecho</option>
        </select>

        <div class="h-full bg-gray-100 col-span-full flex justify-around text-base p-2">
            <button v-if="!editar" type="button" @click="editar = !editar" class="bg-white border-2 rounded-lg border-gray-300 p-2 font-semibold">Modo Edición</button>
            <button v-else type="button" @click="editar = !editar" class="bg-white border-2 rounded-lg border-gray-300 p-2 font-semibold">Modo Solo Lectura</button>
            <button type="button" @click="deleteToDo" class="bg-white border-2 rounded-lg border-gray-300 p-2 font-semibold">Eliminar</button>
        </div>

    </div>






</template>

<style scoped>

</style>
