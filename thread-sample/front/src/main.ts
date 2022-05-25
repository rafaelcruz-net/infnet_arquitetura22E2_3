import Vue from 'vue'
import App from './App.vue'
import Vuetify from "vuetify";
import "vuetify/dist/vuetify.min.css";

Vue.use(Vuetify);


const vuetify = new Vuetify({
  theme: {
    dark: true
  }
});

Vue.config.productionTip = false

new Vue({
  vuetify,
  render: h => h(App),

}).$mount('#app')
