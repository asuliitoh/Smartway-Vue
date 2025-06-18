<script setup>
  
  import { ref } from 'vue'
  import Header from './components/Header.vue';
  import Tarea from './components/Tarea.vue';
  const tareas = ref([ {message: 'Terminar Piolify', done: false}, {message:'Terminar AppChat', done: false}])
  const nuevaTarea = ref('')
  function addTarea() {
    tareas.value.push({message: nuevaTarea.value, done:false});
    nuevaTarea.value='';
  }

</script>

<template>
  <Header class="row-start-1"></Header>
  <div class="min-h-screen grid auto-cols-min grid-cols-2 ">
    
      <section id="cta" class="pl-10 row-start-2 row-span-2 col-start-1 justify-self-center">
        <h1 class="text-7xl text-left font-bold pb-5">¡Bienvenidos a la Operación DataStorm!</h1>
        <p class="text-xl"> Lleva el control de tu día a día con nuestra app ToDo: simple, rápida y pensada para ayudarte
            a cumplir tus objetivos sin estrés. Organiza tus tareas, recibe recordatorios inteligentes y enfócate
            en lo que realmente importa. Empieza ahora y transforma tu caos en claridad con solo unos toques.</p>
      </section>
    
      <div id="input" class="row-start-2 row-span-2 col-start-2 justify-self-center">
        <h2 class="text-4xl font-semibold">Introduce una tarea:</h2>
        <form @submit.prevent="addTarea">
          <input v-model="nuevaTarea" placeholder="Nombre de la tarea">
        </form>
        <template v-for="tarea in tareas">
          <Tarea v-model="tarea.done" :title='tarea.message'></Tarea>
        </template>
      </div>   
 
  </div>

</template>


<style>
@import "tailwindcss";
</style>
