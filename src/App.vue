<script setup>
  
  import { ref } from 'vue'
  import Header from './components/Header.vue';
  import ToDoApp from './components/ToDoApp.vue';

</script>

<template>
 
    <Header></Header>

    <div class="grid grid-cols-2 flex-grow">

      <section id="cta" class="p-10  col-start-1 flex flex-col justify-center">
        <h1 class="text-7xl text-left font-bold pb-5">¡Bienvenidos a la Operación DataStorm!</h1>
        <p class="text-xl"> Lleva el control de tu día a día con nuestra app ToDo: simple, rápida y pensada
        para ayudarte a cumplir tus objetivos sin estrés. Organiza tus tareas, recibe recordatorios inteligentes
        y enfócate en lo que realmente importa. Empieza ahora y transforma tu caos en claridad con solo unos toques.
        </p>
      </section>
        
      <ToDoApp class="col-start-2"></ToDoApp>
      
     

    </div>
    
  

</template>


<style>
@import "tailwindcss";
</style>
