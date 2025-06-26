<script setup>
  import { ref } from 'vue'
  import Header from './components/Header.vue';
  import ToDoApp from './components/ToDoApp.vue';

  const button = ref(false)

</script>

<template>
 
    

    <div class="ml-10 mr-10 grid grid-rows-[10vh_auto] h-screen ">
      <Header class="row-start-1 self-start justify-self-start"></Header>
      <section v-if="!button" class="row-start-2 flex flex-col flex-grow place-self-center">
        <h1 class=" text-xl sm:text-3xl lg:text-5xl xl:text-7xl text-center font-bold pb-5">¡Bienvenidos a la Operación DataStorm!</h1>
        <p class="text-base xl:text-xl text-center pb-5"> Lleva el control de tu día a día con nuestra app ToDo: simple, rápida y pensada
        para ayudarte a cumplir tus objetivos sin estrés. Organiza tus tareas, recibe recordatorios inteligentes
        y enfócate en lo que realmente importa. Empieza ahora y transforma tu caos en claridad con solo unos toques.
        </p>
        <button class="bg-black text-white font-semibold border-gray-900 rounded-xl p-1 text-sm xl:text-base xl:p-2 place-self-center" @click="button = !button">Empieza tu aventura!</button>
      </section>

      <ToDoApp v-else class="place-self-center rounded-4xl w-fit"></ToDoApp>
   

    </div>
    
  

</template>


<style>
@import "tailwindcss";
</style>
