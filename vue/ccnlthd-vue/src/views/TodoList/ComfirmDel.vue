<script setup>

</script>
<template>
    <!-- Modal -->
    <div class="modal fade" id="deleteform" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Delete Comfirmation</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    Are U sure to delete it?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                    <button type="button" @click="$event => $emit('confirm-delete-click')" class="btn btn-primary">Delete</button>
                </div>
            </div>
        </div>
    </div>
</template>