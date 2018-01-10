

import axios from "axios";
//ES6 module syntax

export default {
    data: () => {
        return {
            dataDto: {
                FirstName: "",
                LastName: ""
            }
        }
    },
    methods: {
        getData: function() {
            axios.get( '/api/data',
            {
                params: {}
            }).then((response) => {
                this.dataDto = response.data;
            });
        }
    }
};