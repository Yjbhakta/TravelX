// Travel-X Web Application JavaScript

// Loading screen
window.showLoadingScreen = function() {
    const loadingScreen = document.createElement('div');
    loadingScreen.id = 'loading-screen';
    loadingScreen.innerHTML = `
        <div class="fixed inset-0 bg-gradient-to-br from-blue-600 to-purple-700 flex items-center justify-center z-50">
            <div class="text-center">
                <div class="w-20 h-20 border-4 border-white border-t-transparent rounded-full animate-spin mx-auto mb-4"></div>
                <h2 class="text-2xl font-bold text-white mb-2">Travel-X</h2>
                <p class="text-blue-100">Loading your revolution...</p>
            </div>
        </div>
    `;
    document.body.appendChild(loadingScreen);
};

window.hideLoadingScreen = function() {
    const loadingScreen = document.getElementById('loading-screen');
    if (loadingScreen) {
        loadingScreen.style.opacity = '0';
        loadingScreen.style.transition = 'opacity 0.5s ease';
        setTimeout(() => {
            loadingScreen.remove();
        }, 500);
    }
};

// Smooth scrolling for anchor links
window.scrollToSection = function (elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.scrollIntoView({ 
            behavior: 'smooth',
            block: 'start'
        });
    }
};

// Parallax effect for hero section
window.initParallaxEffect = function() {
    const heroSection = document.querySelector('.hero-background-image');
    if (heroSection) {
        window.addEventListener('scroll', () => {
            const scrolled = window.pageYOffset;
            const rate = scrolled * -0.5;
            heroSection.style.transform = `translateY(${rate}px) scale(1.1)`;
        });
    }
};

// Counter animation for statistics
window.animateCounters = function() {
    const counters = document.querySelectorAll('.stats-card .text-5xl');
    
    const animateValue = (element, start, end, duration) => {
        let startTimestamp = null;
        const step = (timestamp) => {
            if (!startTimestamp) startTimestamp = timestamp;
            const progress = Math.min((timestamp - startTimestamp) / duration, 1);
            
            if (element.textContent.includes('$')) {
                element.textContent = '$' + Math.floor(progress * parseFloat(end.replace('$', '').replace('T', ''))) + 'T';
            } else if (element.textContent.includes('%')) {
                element.textContent = Math.floor(progress * parseFloat(end.replace('%', ''))) + '%';
            } else {
                element.textContent = Math.floor(progress * parseFloat(end));
            }
            
            if (progress < 1) {
                window.requestAnimationFrame(step);
            }
        };
        window.requestAnimationFrame(step);
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const target = entry.target.querySelector('.text-5xl');
                if (target) {
                    const finalValue = target.textContent;
                    animateValue(target, 0, finalValue, 2000);
                }
                observer.unobserve(entry.target);
            }
        });
    });

    counters.forEach(counter => {
        observer.observe(counter.closest('.stats-card'));
    });
};

// Intersection Observer for animations
window.initializeAnimations = function () {
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const fadeObserver = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('animate-fade-in');
            }
        });
    }, observerOptions);

    const scrollObserver = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('visible');
            }
        });
    }, observerOptions);

    // Observe elements for fade-in animation
    document.querySelectorAll('.card, section').forEach(el => {
        fadeObserver.observe(el);
    });

    // Observe elements for scroll-fade animation
    document.querySelectorAll('.scroll-fade, .fade-in').forEach(el => {
        scrollObserver.observe(el);
    });
};

// Ripple effect for buttons
window.initRippleEffect = function() {
    const buttons = document.querySelectorAll('.btn-primary, .btn-secondary');
    
    buttons.forEach(button => {
        button.addEventListener('click', function(e) {
            const ripple = document.createElement('span');
            const rect = this.getBoundingClientRect();
            const size = Math.max(rect.width, rect.height);
            const x = e.clientX - rect.left - size / 2;
            const y = e.clientY - rect.top - size / 2;
            
            ripple.style.cssText = `
                position: absolute;
                width: ${size}px;
                height: ${size}px;
                left: ${x}px;
                top: ${y}px;
                background: rgba(255, 255, 255, 0.3);
                border-radius: 50%;
                transform: scale(0);
                animation: ripple 0.6s linear;
                pointer-events: none;
            `;
            
            this.style.position = 'relative';
            this.style.overflow = 'hidden';
            this.appendChild(ripple);
            
            setTimeout(() => {
                ripple.remove();
            }, 600);
        });
    });
};

// Lazy loading for images
window.initLazyLoading = function() {
    if ('IntersectionObserver' in window) {
        const imageObserver = new IntersectionObserver((entries) => {
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    const img = entry.target;
                    img.src = img.dataset.src;
                    img.classList.remove('lazy');
                    imageObserver.unobserve(img);
                }
            });
        });

        document.querySelectorAll('img[data-src]').forEach(img => {
            imageObserver.observe(img);
        });
    }
};

// Initialize on page load
document.addEventListener('DOMContentLoaded', function() {
    showLoadingScreen();
    
    setTimeout(() => {
        hideLoadingScreen();
        initializeAnimations();
        initParallaxEffect();
        animateCounters();
        initRippleEffect();
        initLazyLoading();
    }, 1000);
});

// Mobile menu toggle
window.toggleMobileMenu = function () {
    const menu = document.getElementById('mobile-menu');
    if (menu) {
        menu.classList.toggle('hidden');
    }
};

// Form validation helpers
window.validateEmail = function (email) {
    const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return re.test(email);
};

window.validatePhone = function (phone) {
    const re = /^[\+]?[1-9][\d]{0,15}$/;
    return re.test(phone.replace(/\s/g, ''));
};

// Add CSS for ripple animation
const style = document.createElement('style');
style.textContent = `
    @keyframes ripple {
        to {
            transform: scale(2);
            opacity: 0;
        }
    }
    
    .lazy {
        filter: blur(5px);
        transition: filter 0.3s;
    }
    
    .lazy.loaded {
        filter: blur(0);
    }
`;
document.head.appendChild(style);