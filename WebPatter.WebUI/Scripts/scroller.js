const testimonials = document.querySelector('.testimonials');
const scroller = testimonials.querySelector('.pattern_list_scroll');
const nextBtn = testimonials.querySelector('.btn.next');
const prevBtn = testimonials.querySelector('.btn.prev');
const itemWidth = testimonials.querySelector('.patterns_list').clientWidth;
let start = scroller.scrollLeft;
scroller.scrollLeft = scroller.scrollWidth; //прокручиваем до конца
let max = scroller.scrollLeft; //узнаем максимальную прокрутку
scroller.scrollLeft = start;
nextBtn.addEventListener('click', scrollToNextItem);
prevBtn.addEventListener('click', scrollToPrevItem);

function scrollToNextItem() {

	if (scroller.scrollLeft !== max)
		// Позиция прокрутки расположена не в начале последнего элемента
		scroller.scrollBy({ left: itemWidth, top: 0, behavior: 'smooth' });
	else
		// Достигнут последний элемент. Возвращаемся к первому элементу, установив для позиции прокрутки 0
		scroller.scrollTo({ left: 0, top: 0, behavior: 'smooth' });
}
function scrollToPrevItem() {
	if (scroller.scrollLeft != 0)
		// Позиция прокрутки расположена не в начале последнего элемента
		scroller.scrollBy({ left: -scroller.scrollWidth, top: 0, behavior: 'smooth' });
	else
		// Это первый элемент. Переходим к последнему элементу, установив для позиции прокрутки ширину скроллера
		scroller.scrollTo({ left: scroller.scrollWidth, top: 0, behavior: 'smooth' });
}