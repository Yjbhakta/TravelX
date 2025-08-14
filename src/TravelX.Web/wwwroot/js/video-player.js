// Video Player JavaScript
window.videoPlayer = {
    openModal: function() {
        document.body.style.overflow = 'hidden';
    },
    
    closeModal: function() {
        document.body.style.overflow = '';
        const video = document.querySelector('#video-modal video');
        if (video) {
            video.pause();
            video.currentTime = 0;
        }
    },
    
    handleKeyboard: function(event) {
        if (event.key === 'Escape') {
            this.closeModal();
        }
    }
};

// Add event listeners
document.addEventListener('keydown', (e) => window.videoPlayer.handleKeyboard(e));