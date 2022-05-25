<template>
  <div id="app">
    <load-component />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import LoadComponent from './components/LoadComponent.vue';

@Component({
  components: {
    LoadComponent,
  },
})
export default class App extends Vue {}
</script>