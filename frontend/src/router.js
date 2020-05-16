import Vue from "vue";
import Router from "vue-router";
import Create from "./components/Create";
import Edit from "./components/Edit";
import Index from "./components/Index";

Vue.use(Router);

export default new Router({
    mode: "history",
    routes: [
        {
            name: 'Create',
            path: '/create',
            component: Create
        },
        {
            name: 'Edit',
            path: '/edit',
            component: Edit
        },
        {
            name: 'Index',
            path: '/index',
            alias: '/',
            component: Index
        },
    ]
});
