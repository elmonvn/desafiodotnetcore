<template>
    <CContainer>
        <CJumbotron>
            <h1>Cadastro de Pessoas</h1>
        </CJumbotron>
        <CNav variant="pills">
            <CNavItem active to="/index">Lista de Cadastrados</CNavItem>
            <CNavItem to="/create">Adicionar Pessoa</CNavItem>
        </CNav>
        <transition name="fade">
            <div class="gap">
                <router-view></router-view>
            </div>
        </transition>
    </CContainer>
</template>

<script>

    export default {}
</script>

<style lang="scss">
    @import "assets/scss/style";

</style>
