<template>

    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <div>First Name: {{dataDto.FirstName}} </div>
                <div>Last Name: {{dataDto.LastName}} </div>
                <button v-on:click="getData();" class="btn">refresh</button>
            </div>
            <div class="col-sm-4">
            </div>
            <div class="col-sm-4">
            </div>
        </div>
    </div>
</template>

<script src="./main.js"></script>