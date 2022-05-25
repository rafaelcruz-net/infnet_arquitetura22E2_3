<template>
  <v-app>
    <v-main>
      <v-container fluid>
        <v-card elevation="0"  class="mx-auto">
          <v-card-title>ASYNC AWAIT REST CALL TESTS</v-card-title>
          <v-card-subtitle class="mt-4">
            <v-row>
              <v-col cols="8">
                <v-slider
                  v-model="numberOfCalls"
                  label="Número de chamada para API"
                  min="1"
                  max="500"
                  thumb-label="always"
                ></v-slider>
              </v-col>
              <v-col cols="4">
                <v-btn class="mr-4" color="primary" @click.prevent="runSync">Executar Sync</v-btn>
                <v-btn class="mr-4" color="accent" @click.prevent="runAsync">Executar Async</v-btn>
                <v-btn @click.prevent="clear">Limpar</v-btn>
              </v-col>
            </v-row>
          </v-card-subtitle>
          <v-card-text>
            <div>
              <v-row class="mx-0">
                 <v-col cols="6">
                  <h1 class="title-2 mb-5">
                    Execuções Síncronas
                  </h1>
                  <label v-if="syncTime > 0" class="subtitle-1">
                    Tempo Total: {{ syncTime }} milisegundos
                  </label>
                  <v-col cols="6">
                  <v-simple-table>
                     <template v-slot:default>
                       <tbody>
                        <tr v-for="c in syncCalls" :key="c.number">
                          <td width="35%">Chamada {{c.number}}</td>
                          <td><v-progress-linear height="25" :indeterminate="!c.finish" :value="100" color="green darken-2"></v-progress-linear></td>
                        </tr>
                       </tbody>
                     </template>
                  </v-simple-table>
                  </v-col>
                </v-col>
                <v-col cols="6">
                  <h1 class="title-2 mb-5">
                    Execuções Assíncronas
                  </h1>
                  <label v-if="asyncTime > 0" class="subtitle-1">
                    Tempo Total: {{ asyncTime }} milisegundos
                  </label>
                  <v-col cols="6">
                  <v-simple-table>
                     <template v-slot:default>
                       <tbody>
                        <tr v-for="c in asyncCalls" :key="c.number">
                          <td width="35%">Chamada {{c.number}}</td>
                          <td><v-progress-linear height="25" :indeterminate="!c.finish" :value="100" color="amber darken-2"></v-progress-linear></td>
                        </tr>
                       </tbody>
                     </template>
                  </v-simple-table>
                  </v-col>
                  
                </v-col>
              </v-row>
            </div>
          </v-card-text>
        </v-card>
      </v-container>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import Axios from "axios";

@Component
export default class LoadComponent extends Vue {
  public numberOfCalls = 50;
  public syncCalls = [] as any;
  public asyncCalls = [] as any;
  public syncTime = null;
  public asyncTime = null;

  runSync() {
    const axios = Axios.create();
    const dateStart = new Date().getTime();
    this.syncCalls = [];
    for (let index = 0; index < this.numberOfCalls; index++) {
      this.syncCalls.push({
        number: index + 1,
        finish: false,
      });
    }

    for (let index = 0; index < this.numberOfCalls; index++) {
      axios.get(`https://localhost:5001/api/Product/${index + 1}/sync`).then(() => {
        this.syncCalls[index].finish = true;
        if (index == this.numberOfCalls - 1) {
          const dateFinish = new Date().getTime();
          this.syncTime = ((dateFinish - dateStart) / 1000) as any;
        }
      });
    }
  }

   runAsync() {
    const axios = Axios.create();
    this.asyncCalls = [];
    const dateStart = new Date().getTime();
    
    for (let index = 0; index < this.numberOfCalls; index++) {
      this.asyncCalls.push( {
        number: index + 1,
        finish: false,
      });
    }

    for (let index = 0; index < this.numberOfCalls; index++) {
      axios.get(`https://localhost:5001/api/Product/${index + 1}/async`).then(() => {
        this.asyncCalls[index].finish = true;
        if (index == this.numberOfCalls - 1) {
          const dateFinish = new Date().getTime();
          this.asyncTime = ((dateFinish - dateStart) / 1000) as any;
        }
      });
    }
  }

  clear() {
    this.syncCalls = [];
    this.asyncCalls = [];
    this.syncTime = null;
    this.asyncTime = null;
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
