import Vue from 'vue'
import VueRouter from 'vue-router';
import VueAxios from 'vue-axios';
import axios from 'axios';
import CoreuiVue from '@coreui/vue';
import NProgress from 'nprogress';

import App from './App.vue';
import router from './router';

import '../node_modules/nprogress/nprogress.css';

Vue.use(VueRouter);
Vue.use(VueAxios, axios);
Vue.use(CoreuiVue)

Vue.config.productionTip = false;

router.beforeResolve((to, from, next) => {
    if (to.name) {
        NProgress.start();
    }
    next();
});

router.afterEach(() => {
    NProgress.done()
});

new Vue({
    render: h => h(App),
    router
}).$mount('#app')