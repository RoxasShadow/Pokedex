pokedex = PokemonCollection();
lang = Languages.ITA;

function fill(i) {
	pokemon = pokedex[i-1];
	$('#num').html(td[lang][0]);
	$('#name').html(td[lang][1]);
	$('#mf').html(td[lang][2]);
	$('#abilities').html(td[lang][3]);
	$('#stats').html(td[lang][4]);
		
	$('#_num').html(pokemon['num']);
	$('#_name').html(pokemon['name'][lang]);
	$('#_mf').html(pokemon['mf']);
	$('#_abilities').html(pokemon['ability1'][lang]+' '+pokemon['ability2'][lang]);
	$('#_stats').html(pokemon['hp']+' '+pokemon['atk']+' '+pokemon['def']+' '+pokemon['spatk']+' '+pokemon['spdef']+' '+pokemon['spe']);
	
	id = pokemon['num'];
	if(id.length < 10)
		id = '00'+id;
	else if(id.length < 100)
		id = '0'+id;
	$('#artwork').html('<img src="Artwork/'+id+'.png" alt="'+pokemon['name'][lang]+'" />');
	$('#artwork').append('<img src="Artwork/'+id+'-mini.png" alt="'+pokemon['name'][lang]+'" />');
}
	
$(document).ready(function() {		
	n = (window.location.hash) ? parseInt(window.location.hash.replace('#', '')) : 1;
	if(n == 0 || n > 649)
		n = 1;
	fill(n);
	
	$('.dock-item2').live('click', function() {
		n = $(this).attr('href').replace('#', '');
		if(n == 0 || n > 649)
			n = 1;
		fill(n);
	});
		
	dock = $('#dock-container2');
	slider = $("#slider");
	x = 0;
	for(i=0; i<649; ++i) {
		dock.append('<a style="width: 48px; left: '+x+'px;" class="dock-item2" href="#'+pokedex[i]['num']+'"><span>'+pokedex[i]['name'][lang]+'</span><img src="Sprite/'+i+'.png" alt="'+pokedex[i]['name'][lang]+'"></a>');
		x += 32;
	}
		
	slider.slider({
		slide: function(event, ui) {
			dock.css('margin-left', (dock.width() > slider.width()) ? Math.round(ui.value / 100 * (slider.width() - dock.width()))+'px' : 0 );
		}
	});
			
	$('#dock2').Fisheye({
		maxWidth: 96,
		items: 'a',
		itemsText: 'span',
		container: '.dock-container2',
		itemWidth: 48,
		proximity: 80,
		alignment : 'left',
		valign: 'bottom',
		halign : 'left'
	});
});