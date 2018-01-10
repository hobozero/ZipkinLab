import "./index.less";
import "bootstrap";
//avoids: You are using the runtime-only build of Vue where the template compiler is not available
//import Vue from "vue";
import Vue from 'vue/dist/vue.js'
import MainComponent from "./main.vue";


let dataVueComponent = new Vue({
	el: '#dataVue',
	replace: false,
	template:     `
	<main-component />
	`,
	
	components: {MainComponent}
});